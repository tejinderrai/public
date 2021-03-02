Login-AzAccount

# Virtual Machine names split by a comma to specify the virtual machine name,container, folder in the CSV file
$VMNames = Import-Csv -LiteralPath FULL-PATH-TO-CSV-FILE
$TargetStorageAccountName = "YOUR-STORAGE-ACCOUNT-NAME"
$TargetStorageAccountKey = "YOUR-STORAGE-ACCOUNT-KEY"


Function CopyManagedDiskToBlobStorage ($VMResourceGroupName, $DiskName, $StorageAccountName, $StorageAccountKey, $DestinationContainer, $DestinationFolder) {

    $DiskAccess = Grant-AzDiskAccess -ResourceGroupName $VMResourceGroupName -DiskName $DiskName -DurationInSecond 3600 -Access Read 
    $DestinationStorageContext = New-AzStorageContext –StorageAccountName $StorageAccountName -StorageAccountKey $StorageAccountKey

    if ($DestinationFolder)
    {
    
        Start-AzStorageBlobCopy -AbsoluteUri $DiskAccess.AccessSAS -DestContainer $DestinationContainer -DestContext $DestinationStorageContext -DestBlob "$DestinationFolder/$DiskName"

    }
    else
    {
        Start-AzStorageBlobCopy -AbsoluteUri $DiskAccess.AccessSAS -DestContainer $DestinationContainer -DestContext $DestinationStorageContext -DestBlob $DiskName

    }
    

}


Function CreateAzureBlobStorageContainer ($StorageAccountName, $StorageAccountKey, $ContainerName) {

    try {

        $StorageContext = New-AzStorageContext –StorageAccountName $StorageAccountName -StorageAccountKey $StorageAccountKey
        New-AzStorageContainer -Context $StorageContext -Name $ContainerName

    }
    catch {}

}

# Main Execution Section

$VMNames | Foreach {
    
    $Disks = @()
    $VMResourceName = $_.VMName
    $TargetStorageContainer = $_.TargetStorageContainer
    $TargetFolder = $_.TargetFolder

    Write-host "Copying Disks for:" $_.VMName

    # Get the current VM
    $VMObject = Get-AzVM | Where-Object { $_.Name -eq $VMResourceName }
    $VMRG = $VMObject.ResourceGroupName

    # Stop the VM
    Stop-AzVM -Name $VMResourceName -ResourceGroupName $VMRG -Force

    $VMRG = $VMObject.ResourceGroupName
    
    # Query all Virtual Machine Disk Names
    $Disks += $VMObject.StorageProfile.OsDisk.Name
    $VMObject.StorageProfile.DataDisks | Foreach {

        $Disks += $_.Name

    }

    Foreach ($disk in $Disks) {

        Write-host "Copying Disk: $disk to: $TargetStorageAccountName/$TargetStorageContainer"        
        CopyManagedDiskToBlobStorage -VMResourceGroupName $VMRG -DiskName $disk -StorageAccountName $TargetStorageAccountName -StorageAccountKey $TargetStorageAccountKey -DestinationContainer $TargetStorageContainer -DestinationFolder $TargetFolder

    }
}
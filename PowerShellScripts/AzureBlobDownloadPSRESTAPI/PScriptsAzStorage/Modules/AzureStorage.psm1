Function ListAzStorageBlobs ([string]$StorageAccountName, [string]$StorageAccountContainerName, [string]$AccessToken) {

    $AuthHeaders = @{
    'Authorization' = "Bearer $AccessToken"
    'x-ms-version' = '2025-05-05'
    }
    
    $StorageURI = "https://" + $StorageAccountName + ".blob.core.windows.net/" + $StorageAccountContainerName + "?restype=container&comp=list" 
    
    $BlobList = Invoke-RestMethod -Method Get -Headers $AuthHeaders -Uri $StorageURI #"https://$StorageAccountName.blob.core.windows.net/$StorageAccountContainerName?restype=container&comp=list" 
    $xml = [xml]$BlobList.Substring($BlobList.IndexOf('<'))
    $FileNames = $xml.ChildNodes.Blobs.Blob.Name                        
                                                                                                                        
    return $FileNames

}


Function DownloadAzStorageBlob ([string]$StorageAccountName, [string]$StorageAccountContainerName, [string]$AccessToken, [string]$BlobName, [string]$OutputFolder) {

    # Header date
    $xmsDate = (Get-Date -Format "R").ToUpper()

    $AuthHeaders = @{
        'Authorization' = "Bearer $AccessToken"
        'x-ms-version' = '2025-05-05'
        'x-ms-date' = $xmsDate
    }
    
    $EncodeBlobFileName = [System.Web.HttpUtility]::UrlPathEncode($BlobName)

    $BlobURI  = "https://" + $StorageAccountName + ".blob.core.windows.net/" + $StorageAccountContainerName + "/" + $BlobName
    $OutputFilePath = $OutputFolder + "\" + $BlobName
    Invoke-WebRequest -UseBasicParsing -Method Get -Headers $AuthHeaders -Uri $BlobURI -OutFile $OutputFilePath

}

Function DeleteAzStorageBlob ([string]$StorageAccountName, [string]$StorageAccountContainerName, [string]$AccessToken, [string]$BlobName) {

    # Header date
    $xmsDate = (Get-Date -Format "R").ToUpper()

    $AuthHeaders = @{
        'Authorization' = "Bearer $AccessToken"
        'x-ms-version' = '2025-05-05'
        'x-ms-date' = $xmsDate
    }
    
    $EncodeBlobFileName = [System.Web.HttpUtility]::UrlPathEncode($BlobName)

    $BlobURI  = "https://" + $StorageAccountName + ".blob.core.windows.net/" + $StorageAccountContainerName + "/" + $BlobName

    Invoke-WebRequest -UseBasicParsing -Method Delete -Headers $AuthHeaders -Uri $BlobURI -OutFile $Null

}

Export-ModuleMember ListAzStorageBlobs
Export-ModuleMember DownloadAzStorageBlob
Export-ModuleMember DeleteAzStorageBlob
# Script Base Path
$ScriptBasePath = "C:\PScriptsAzStorage"
$ConfigFile = "BlobDownload.json"
# Set working location
Set-Location -Path $ScriptBasePath

# Import PowerShell Modules required for the script
Import-Module .\Modules\PSSystem.psm1
Import-Module .\Modules\PSLogger.psm1
Import-Module .\Modules\PSConfig.psm1
Import-Module .\Modules\AzureIdentity.psm1
Import-Module .\Modules\AzureStorage.psm1

# Get Script Config Settings
$PSEnvConfig = GetScriptConfig -ConfigFileWithPath "$ScriptBasePath\Config\$ConfigFile"

# Main Script
Write-To-LogFile -LogEntry "Starting script." -LogFilePath $PSEnvConfig.LoggingDirectory -LogFileName $PSEnvConfig.LogFileName
# Authenticate with Managed Identity to retrieve an access token for Azure Storage
Write-Host "Authenticating to Azure"
Write-To-LogFile -LogEntry "Authenticating to Azure" -LogFilePath $PSEnvConfig.LoggingDirectory -LogFileName $PSEnvConfig.LogFileName
$AccessToken = GetAzureStorageTokenManagedIdentity;
Write-To-LogFile -LogEntry "Token Acquired" -LogFilePath $PSEnvConfig.LoggingDirectory -LogFileName $PSEnvConfig.LogFileName

# Get Blob List from Storage Account
Write-Host "Getting a list of blobs from Azure Storage account:" $PSenvConfig.AzureBlobStorageAccountName "container:" $PSEnvConfig.AzureBlobStorageContainerName
$BlobList = ListAzStorageBlobs -StorageAccountName $PSEnvConfig.AzureBlobStorageAccountName -StorageAccountContainerName $PSEnvConfig.AzureBlobStorageContainerName -AccessToken $AccessToken 

# Download and delete blob if successfully downloaded to download folder
if ($BlobList.Count -gt 0) {

    $BlobList | ForEach-Object {

        $BlobName = $_
        Write-host "Downloading blob: " $BlobName

        Write-To-LogFile -LogEntry "Downloading $BlobName" -LogFilePath $PSEnvConfig.LoggingDirectory -LogFileName $PSEnvConfig.LogFileName
         
        DownloadAzStorageBlob -StorageAccountName $PSEnvConfig.AzureBlobStorageAccountName -StorageAccountContainerName $PSEnvConfig.AzureBlobStorageContainerName -AccessToken $AccessToken -BlobName $BlobName -OutputFolder $PSEnvConfig.LocalBlobDownloadPath

        $OutputFilePath = $PSEnvConfig.LocalBlobDownloadPath + "\" + $BlobName

        if (Test-Path -Path  $OutputFilePath) {
            Write-host "file downloaded"

            Write-To-LogFile -LogEntry "Finished downloading $BlobName" -LogFilePath $PSEnvConfig.LoggingDirectory -LogFileName $PSEnvConfig.LogFileName

            Write-host "Deleting Blob Storage File"
            Write-To-LogFile -LogEntry "Deleting $BlobName" -LogFilePath $PSEnvConfig.LoggingDirectory -LogFileName $PSEnvConfig.LogFileName
            DeleteAzStorageBlob -StorageAccountName $PSEnvConfig.AzureBlobStorageAccountName -StorageAccountContainerName $PSEnvConfig.AzureBlobStorageContainerName -AccessToken $AccessToken -BlobName $BlobName
            Write-To-LogFile -LogEntry "$BlobName deleted" -LogFilePath $PSEnvConfig.LoggingDirectory -LogFileName $PSEnvConfig.LogFileName
        }
        else {
            Write-host "File donwload failed!"
            Write-To-LogFile -LogEntry "$BlobName download failed!" -LogFilePath $PSEnvConfig.LoggingDirectory -LogFileName $PSEnvConfig.LogFileName
        }
    }
}
else {
    Write-host "No blobs found"
    Write-To-LogFile -LogEntry "No blobs found, nothing to do" -LogFilePath $PSEnvConfig.LoggingDirectory -LogFileName $PSEnvConfig.LogFileName
}

Write-host "Finished."
Write-To-LogFile -LogEntry "Finished." -LogFilePath $PSEnvConfig.LoggingDirectory -LogFileName $PSEnvConfig.LogFileName
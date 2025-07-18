# Login With Managed Identity on an Azure Virtual Machine

Function GetAzureStorageTokenManagedIdentity () {

    # Get an access token for managed identities for Azure Storage
    $response = Invoke-WebRequest -Uri 'http://169.254.169.254/metadata/identity/oauth2/token?api-version=2021-01-01&resource=https%3A%2F%2Fstorage.azure.com%2F' `
                              -Headers @{Metadata="true"}
    
    $content = $response.Content | ConvertFrom-Json
    $accesstoken = $content.access_token
   
    return $accesstoken

}

Export-ModuleMember GetAzureStorageTokenManagedIdentity
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Microsoft.AspNetCore.DataProtection;

namespace AzKeyVaultSecretReaderConsoleApp
{
    internal class KeyVaultHelper
    {
        public static async Task<KeyVaultSecret> GetKeyVaultSecret(Uri KeyVaultURI, string KeyVaultSecretName)
        {
            var credential = new DefaultAzureCredential();            
            var keyVaultSecretClient = new SecretClient(KeyVaultURI, new DefaultAzureCredential());

            KeyVaultSecret keyVaultSecret = await keyVaultSecretClient.GetSecretAsync(KeyVaultSecretName);
            return keyVaultSecret;
        }
    }
}

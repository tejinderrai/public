using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Azure.Security.KeyVault.Secrets;
using Azure.Identity;

namespace KeyVaultSecretReaderFunctionApp
{
    public static class KeyVaultSecretReaderFunctionApp
    {
        [FunctionName("KeyVaultSecretReaderFunctionApp")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            var credential = new DefaultAzureCredential();
            string vaultUrl = Environment.GetEnvironmentVariable("KEYVAULTURL");
            string mySecretName = Environment.GetEnvironmentVariable("KEYVAULTSECRETNAME");

            log.LogInformation("Key Vault URL is: {0}", vaultUrl);
            log.LogInformation("Key Vault secret name is: {0}", mySecretName);

            var keyVaultSecretClient = new SecretClient(new Uri(vaultUrl), new DefaultAzureCredential());
            var secret = keyVaultSecretClient.GetSecret(mySecretName).Value;
            log.LogInformation("Key Vault Secret is: {0}", secret.Value);

            string responseMessage = "This HTTP triggered function executed successfully. Pass a name in the query string or in the request body for a personalized response.";

            return new OkObjectResult(responseMessage);
        }
    }
}

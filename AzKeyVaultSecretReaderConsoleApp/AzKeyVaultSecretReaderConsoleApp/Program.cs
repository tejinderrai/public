using AzKeyVaultSecretReaderConsoleApp;
using Azure.Security.KeyVault.Secrets;
using Microsoft.Extensions.Configuration;

IConfigurationBuilder builder = new ConfigurationBuilder().AddJsonFile("appsettings.json");
IConfigurationRoot appConfig = builder.Build();

string kVaultURI = appConfig["KeyVaultURI"];
string kVSecret = appConfig["KeyVaultSecretName"];

try
{
    KeyVaultSecret secret = await KeyVaultHelper.GetKeyVaultSecret(new Uri(kVaultURI), kVSecret);
    if (!string.IsNullOrEmpty(secret.Value))
    {
        Console.WriteLine("Key Vault Secret is: {0}", secret.Value);
    }
    else
    {
        Console.WriteLine("Key value is empty!");
    }
}
catch (Exception ex)
{
    Exception e = ex;
    Console.WriteLine($"An error occurred: {e.Message}");
}

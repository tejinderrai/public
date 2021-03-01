using Microsoft.AspNetCore.Connections;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Azure.Cosmos.Fluent;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Configuration;
using CosmosWorld.Code;


namespace CosmosWorld.Data
{
    public class QueryCosmosDB
    {

        public static CosmosClient CreateCosmosDBClient()
        {
            CosmosClientBuilder cosmosClientBuilder = new CosmosClientBuilder(
            CosmosDBSettings.EndpointUrl, CosmosDBSettings.AuthorizationKey)
            .WithConsistencyLevel(ConsistencyLevel.Session)
            .WithApplicationRegion(Regions.UKSouth);

            CosmosClient client = cosmosClientBuilder.Build();

            return client;     
        }
        public static async Task<List<CountryData>> ReadAllItems(Container container)
        {
            // Read all items in a container
            List<CountryData> CountriesList = new List<CountryData>();

            string CQuery = "SELECT * FROM c";
            QueryDefinition queryDefinition = new QueryDefinition(CQuery);
            using (FeedIterator<CountryData> resultSet = container.GetItemQueryIterator<CountryData>(
                queryDefinition: queryDefinition,
                requestOptions: new QueryRequestOptions()
                {
                    PartitionKey = new PartitionKey(SettngsManager.GetConfigurationSetting("CosmosDBConnectionString", "PKey")),
                }))

                while (resultSet.HasMoreResults)
                {
                    FeedResponse<CountryData> response = await resultSet.ReadNextAsync();
                    CountryData countries = response.FirstOrDefault();

                    CountriesList.AddRange(response);
                }

            return CountriesList;
        }
    }

    public static class CosmosDBSettings
    {
        public static string DatabaseName = SettngsManager.GetConfigurationSetting("CosmosDBConnectionString", "Database");
        public static string CollectionId = SettngsManager.GetConfigurationSetting("CosmosDBConnectionString", "Collection");
        public static string EndpointUrl = SettngsManager.GetConfigurationSetting("CosmosDBConnectionString", "CosmosDBService");
        public static string AuthorizationKey = SettngsManager.GetConfigurationSetting("CosmosDBConnectionString", "CosmosDBKey");
    }
}

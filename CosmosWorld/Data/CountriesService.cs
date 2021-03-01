using Microsoft.Azure.Cosmos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using CosmosWorld.Code;

namespace CosmosWorld.Data
{
    public class CountriesService
    {
      

        public static List<string> Countries = new List<string>();

        public static async Task PopulateCountries()
        {

            CosmosClient client = Data.QueryCosmosDB.CreateCosmosDBClient();
            Container container = client.GetContainer(SettngsManager.GetConfigurationSetting("CosmosDBConnectionString", "Database"), SettngsManager.GetConfigurationSetting("CosmosDBConnectionString", "Collection"));
            Countries = await QueryAllCountryItemsAsync(container);

        }
        public static async Task<List<string>> QueryAllCountryItemsAsync(Container container)
        {

            var sqlQueryText = "SELECT DISTINCT VALUE c.country FROM Countries c ORDER BY c.country ASC";

            QueryDefinition queryDefinition = new QueryDefinition(sqlQueryText);
            FeedIterator<string> queryResultSetIterator = container.GetItemQueryIterator<string>(queryDefinition);

            List<string> countries = new List<string>();

            while (queryResultSetIterator.HasMoreResults)
            {
                FeedResponse<string> currentResultSet = await queryResultSetIterator.ReadNextAsync();
                foreach (string c in currentResultSet)
                {
                    countries.Add(c);
                }
            }

            return countries;
        }

        public static async Task<List<string>> QueryCityNames(string SelectedCountry)
        {
            CosmosClient client = Data.QueryCosmosDB.CreateCosmosDBClient();
            Container container = client.GetContainer(SettngsManager.GetConfigurationSetting("CosmosDBConnectionString", "Database"), SettngsManager.GetConfigurationSetting("CosmosDBConnectionString", "Collection"));

            var sqlQueryText = ("SELECT c.city FROM countries c where c.country = '" + SelectedCountry + "' ORDER BY c.city");
            QueryDefinition queryDefinition = new QueryDefinition(sqlQueryText);
            FeedIterator<CountryData> queryResultSetIterator = container.GetItemQueryIterator<CountryData>(queryDefinition);

            List<string> cities = new List<string>();

            try
            {

                while (queryResultSetIterator.HasMoreResults)

                {
                    FeedResponse<CountryData> currentResultSet = await queryResultSetIterator.ReadNextAsync();
                    foreach (CountryData c in currentResultSet)
                    {
                        cities.Add(c.City);
                    }
                }
            }
            catch (Exception ex)
            {

                var e = ex.Message;

            }

            return cities;
        }

        public static async Task<List<CountryData>> QueryCityCoordinates(string SelectedCountry, string SelectedCity)
        {

            CosmosClient client = Data.QueryCosmosDB.CreateCosmosDBClient();
            Container container = client.GetContainer(SettngsManager.GetConfigurationSetting("CosmosDBConnectionString", "Database"), SettngsManager.GetConfigurationSetting("CosmosDBConnectionString", "Collection"));

            var sqlQueryText = ("SELECT c.lat, c.lng FROM countries c where c.country = '" + SelectedCountry + "'" + " AND c.city = '" + SelectedCity + "'");
       
            QueryDefinition queryDefinition = new QueryDefinition(sqlQueryText); 
            FeedIterator<CountryData> queryResultSetIterator = container.GetItemQueryIterator<CountryData>(queryDefinition);

            List<CountryData> CountryInfo = new List<CountryData>();

                try
                {

                    while (queryResultSetIterator.HasMoreResults)

                    {
                        FeedResponse<CountryData> currentResultSet = await queryResultSetIterator.ReadNextAsync();
                        foreach (CountryData c in currentResultSet)
                        {
                            CountryInfo.Add(c);
                        }
                    }
                }
                catch (Exception ex)
                {

                    var e = ex.Message;

                }

                return CountryInfo;
            } 
    }
}

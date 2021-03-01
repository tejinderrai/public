using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace CosmosWorld.Code 
{
    public class SettngsManager
    {
        public static IConfiguration _configuration { get; set; }

        public static string GetConfigurationSetting(string Section, string Key)
        {
            string value;

            value = _configuration.GetSection(Section).GetValue<string>(Key);

            return value;
        }
    }
}

using Azure.Core.Extensions;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace CourseCompletionsProcessor
{
    public static class JSONConfigurationBuilder
    {
        public static IConfiguration BuildConfigurationSettings() { 

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
        
            IConfiguration configuration = builder.Build();
            
            return configuration;
        }
    }
}

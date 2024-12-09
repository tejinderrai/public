using Microsoft.Extensions.Configuration;
using Microsoft.Graph.Drives.Item.Items.Item.GetActivitiesByInterval;
using Microsoft.Graph.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseCompletionsProcessor
{
    public static class References
    {

        // These will be parameters in the configuration in the environment and not in code and not in a settings file
        public static string MailFolderName { get; set;}//"inbox";

        public static string MailEmailAddress { get; set; }

        public static string MailSubjectSearchString { get; set; }
        
        public static string ProcessedMessagesFolderName { get; set; } //= "ProcessedMessages";
       
        // Azure Storage - this will be a managed identity in production using Azure.Indentity DefaultCredential()
        public static string AzureStorageConnectionString { get; set; } 
        
        // Name of the file share
        public static string AzureStorageFileShareName { get; set; } // "coursecompletions";

    }
}

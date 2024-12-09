using Microsoft.Graph;
using Microsoft.Graph.Models;
using Azure.Identity;
using Microsoft.Graph.Users.Item.Messages.Item.Move;
using Azure.Storage.Files.Shares;
using Azure.Storage.Files.Shares.Models;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Azure;
using Microsoft.Kiota.Serialization;
using System.Net.Mail;
using Microsoft.Extensions.Configuration;

namespace CourseCompletionsProcessor
{
    internal class Program
    {
        static async Task Main()
        {
            int ProcessedMessageCount = 0;
            int processedAttachmentCount = 0;

            Console.WriteLine("Started mailbox processor...");
            // Initialise configuration
            IConfiguration configuration = JSONConfigurationBuilder.BuildConfigurationSettings();

            // Initialise the application settings
            References.MailFolderName = configuration["AppSettings:MailFolderName"] ?? "";
            References.MailEmailAddress = configuration["AppSettings:MailEmailAddress"] ?? "";
            References.MailSubjectSearchString = configuration["AppSettings:MailSubjectSearchString"] ?? ""; 
            References.ProcessedMessagesFolderName = configuration["AppSettings:ProcessedMessagesFolderName"] ?? "";
            References.AzureStorageConnectionString = configuration["AppSettings:AzureStorageConnectionString"] ?? "";
            References.AzureStorageFileShareName = configuration["AppSettings:AzureStorageFileShareName"] ?? "";
            References.MailEmailAddress = configuration["AppSettings:MailEmailAddress"] ?? "";
            AuthContext.ClientId = configuration["AppSettings:MSEntraApplicationClientId"] ?? "";
            AuthContext.Secret = configuration["AppSettings:MSEntraApplicationSecret"] ?? "";
            AuthContext.TenantId = configuration["AppSettings:MSEntraApplicationTenantId"] ?? "";

            // Retrieve the messages from the specified mailbox folder
            var messages = await MSGraphOperations.GetMessageCollection();

            // Process the message collection
            try
            { 
                foreach (var message in messages.Value)
                {
                    // Check if the subject contains course completions - can be any attribute of the message or content
                    if (message.Subject.ToString().Contains(References.MailSubjectSearchString))
                    {
                        ProcessedMessageCount++;
                        Console.WriteLine("--------------------------------------------------------------------------------------------------------");
                        Console.WriteLine($"Found course files.");
                        Console.WriteLine($"Processing Message ID: { message.Id.ToString()}");
                        Console.WriteLine($"Received Date: {message.ReceivedDateTime?.ToString("yyyy-MM-dd HH:mm:ss")} from {message.From.EmailAddress.Address}");
                        Console.WriteLine($"Message From: {message.From.EmailAddress.Address}");
                        Console.WriteLine($"Subject: {message.Subject}");

                        var attachments = await MSGraphOperations.GetMessageAttachmentCollection(message);

                        foreach (var attachment in attachments.Value)    
                        {
                            Console.WriteLine($"Attachment ID: {attachment.Id}");
                            Console.WriteLine($"Attachment Name: {attachment.Name}");
                            Console.WriteLine($"Attachment Size in bytes: {attachment.Size}");

                            if (attachment is FileAttachment fileAttachment)
                            {
                                var item = (FileAttachment)attachment;

                                bool uploadResult = await MSAzureStorageOperations.UploadAttachmentToAureFileShare(item);

                                if (uploadResult == true)
                                {
                                    Console.WriteLine($"File attachment: {attachment.Name} uploaded.");
                                    processedAttachmentCount++;
                                }
                                else
                                {
                                    Console.WriteLine($"Error uploading file attachment: {attachment.Name}");
                                }
                            }
                        }
                        // Move the message to the processed folder
                        var messageMove = MSGraphOperations.MoveProcessedMessagesToProcessedFolder(message.Id);
                        Console.WriteLine("--------------------------------------------------------------------------------------------------------");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred - details: {ex.InnerException.ToString()}");
            }

            Console.WriteLine($"Processed {ProcessedMessageCount} messages.");
            Console.WriteLine($"Processed {processedAttachmentCount} attachments."); 
            Console.WriteLine("Finished.");
        }
    }
}
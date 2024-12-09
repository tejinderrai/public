using Azure;
using Azure.Identity;
using Azure.Storage.Files.Shares;
using Microsoft.Graph;
using Microsoft.Graph.Models;
using Microsoft.Graph.Users.Item.Messages.Item.Move;
using System.Net.Mail;

namespace CourseCompletionsProcessor
{
    public  class MSGraphOperations
    {
        public static GraphServiceClient CreateGraphClient()
        {
            ClientSecretCredential? _clientSecretCredential;
            _clientSecretCredential = new ClientSecretCredential(AuthContext.TenantId,
            AuthContext.ClientId, AuthContext.Secret, new TokenCredentialOptions { AuthorityHost = AzureAuthorityHosts.AzurePublicCloud });

            var _graphClient = new GraphServiceClient(_clientSecretCredential,
            new[] { "https://graph.microsoft.com/.default" });
            return _graphClient;
        }

        public static async Task<AttachmentCollectionResponse> GetMessageAttachmentCollection(Message message)
        {
            AttachmentCollectionResponse attachmentCollectionResponse = new AttachmentCollectionResponse();

            try
            {
                var _graphClient = MSGraphOperations.CreateGraphClient();
                attachmentCollectionResponse = await _graphClient.Users[References.MailEmailAddress].Messages[message.Id].Attachments.GetAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return attachmentCollectionResponse;
        }

        public static async Task<MessageCollectionResponse> GetMessageCollection()
        {
            MessageCollectionResponse messageCollectionResponse = new MessageCollectionResponse();

            try
            {
                var _graphClient = MSGraphOperations.CreateGraphClient();
                messageCollectionResponse = await _graphClient.Users[References.MailEmailAddress].MailFolders[References.MailFolderName].Messages.GetAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return messageCollectionResponse;
        }

        public static async Task<bool> MoveProcessedMessagesToProcessedFolder(string MessageId)
        {
            var _graphClient = MSGraphOperations.CreateGraphClient();
            
            // Iterate the mailbox to get the folder ID equal to ProcessedMessages i.e. do not hard code folder id it is computed at runtime
            var folders = _graphClient.Users[References.MailEmailAddress].MailFolders.GetAsync().Result;
            var folderId = "";

            foreach (var folder in folders.Value)
            {
                if (folder.DisplayName == References.ProcessedMessagesFolderName)
                {
                    folderId = folder.Id;
                }
            }

            // Create the request body for the move operation - the destination folder Id
            var requestBody = new MovePostRequestBody
            {
                DestinationId = folderId,
            };

            // Move the message to processed messages folder
            var moved = _graphClient.Users[References.MailEmailAddress].Messages[MessageId].Move.PostAsync(requestBody).Result;
            return true;
        }
    }
}

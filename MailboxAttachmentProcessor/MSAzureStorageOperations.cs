using Azure.Storage.Files.Shares;
using Azure;
using Microsoft.Graph.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseCompletionsProcessor
{
    public class MSAzureStorageOperations
    {
        // Note: Fixed location of Azure Storage Location
        public static async Task<bool> UploadAttachmentToAureFileShare(FileAttachment attachment)
        {
            bool result = false;

            try
            {
                var item = (FileAttachment)attachment;

                ShareFileClient fileClient = new ShareFileClient(References.AzureStorageConnectionString, References.AzureStorageFileShareName, item.Name);

                using (MemoryStream stream = new MemoryStream(item.ContentBytes))
                {
                    await fileClient.CreateAsync(stream.Length);

                    Console.WriteLine($"Uploading attachment file to Azure File Share: {attachment.Name}");

                    await fileClient.UploadRangeAsync(
                        new HttpRange(0, stream.Length),
                        stream);
                };

            }
            catch (Exception ex)
            {

                Console.WriteLine($"Exception: {ex.Message}");
                return false;

            }

            return true;
        }

    }
}

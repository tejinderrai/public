using Azure;
using Azure.Storage.Files.Shares;
using CourseCompletionsProcessor;
using Microsoft.Graph.Models;
using System;
using System.IO;

namespace MailBoxAttachmentProcessor
{
    internal class LocalStorageOperations
    {
        public static async Task<bool> DownloadAttachmentToLocalFolder(FileAttachment attachment, string Folder)
        {
            bool result = false;

            try
            {
                var item = (FileAttachment)attachment;

                string filePath = Path.Combine(Folder, item.Name);

                // Load and save the attachment
                using (MemoryStream stream = new MemoryStream(item.ContentBytes))
                {
                    stream.Position = 0; // Reset stream position
                    using (FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                    {
                        stream.CopyTo(fs);
                    }

                    Console.WriteLine($"Saved: {filePath}");

                }
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

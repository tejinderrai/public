﻿using Azure.Storage;
using Azure.Storage.Blobs;
using Azure.Storage.Sas;

namespace BlazorSimpleAI.Data
{
    public class AzureBlobOperations
    {
        //public static async Task<Uri> CreateServiceSASBlob(string FileName, string storedPolicyName = null)
        //{
        //    //  Creates a client to the BlobService using the connection string.
        //    var blobServiceClient = new BlobServiceClient(storageConnectionString);

        //    //  Gets a reference to the container.
        //    var blobContainerClient = blobServiceClient.GetBlobContainerClient(< ContainerName >);

        //    //  Gets a reference to the blob in the container
        //    BlobClient blobClient = blobContainerClient.GetBlobClient(< BlobName >);

        //    //  Defines the resource being accessed and for how long the access is allowed.
        //    var blobSasBuilder = new BlobSasBuilder
        //    {
        //        StartsOn = DateTime.UtcNow.AddHours(-1),
        //        ExpiresOn = DateTime.UtcNow.AddMinutes(5),
        //        BlobContainerName = < ContainerName>,
        //        BlobName = FileName,
        //    };

        //    //  Defines the type of permission.
        //    blobSasBuilder.SetPermissions(BlobSasPermissions.Write);

        //    //  Builds an instance of StorageSharedKeyCredential      
        //    var storageSharedKeyCredential = new StorageSharedKeyCredential(< AccountName >, < AccountKey >);

        //    //  Builds the Sas URI.
        //    BlobSasQueryParameters sasQueryParameters = blobSasBuilder.ToSasQueryParameters(storageSharedKeyCredential);
        //    return sasUri;
        //    }
        }
}

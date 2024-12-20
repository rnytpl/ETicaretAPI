﻿using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using ETicaretAPI.Application.Abstractions.Storage.Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Infrastructure.Services.Storage.Azure
{
    public class AzureStorage : Storage, IAzureStorage
    {
        /// <summary>
        ///  The BlobServiceClient class allows you to manipulate Azure Storage resources and blob containers.
        ///  The BlobContainerClient class allows you to manipulate Azure Storage containers and their blobs.
        ///  The BlobClient class allows you to manipulate Azure Storage blobs.
        /// </summary>
        readonly BlobServiceClient _blobServiceClient;
        BlobContainerClient _blobContainerClient;

        public AzureStorage(IConfiguration configuration)
        {
            
            _blobServiceClient = new(configuration["Storage:Azure"]);

            
        }

        public async Task DeleteAsync(string containerName, string fileName)
        {
            _blobContainerClient = _blobServiceClient.GetBlobContainerClient(containerName);
            BlobClient blobClient = _blobContainerClient.GetBlobClient(fileName);
            await blobClient.DeleteAsync();
           
        }

        public async Task<bool> DeleteFromStorage(string blobName)
        {
            _blobContainerClient = _blobServiceClient.GetBlobContainerClient("photo-images");
            //BlobClient blobClient = _blobContainerClient.GetBlobClient(blobName);
            var response = _blobContainerClient.DeleteBlob(blobName,DeleteSnapshotsOption.IncludeSnapshots);
            //blobClient.Delete
            //var result = _blobContainerClient.DeleteBlob(blobName);

            return true;

        }

        public List<string> GetFiles(string containerName)
        {
            _blobContainerClient = _blobServiceClient.GetBlobContainerClient(containerName);
            return _blobContainerClient.GetBlobs().Select(b => b.Name).ToList();

        }

        public bool HasFile(string containerName, string fileName)
        {
            _blobContainerClient = _blobServiceClient.GetBlobContainerClient(containerName);
            return _blobContainerClient.GetBlobs().Any(b => b.Name == fileName);
            

        }
         
        public async Task<List<(string fileName, string pathOrContainerName)>> UploadAsync(string containerName, IFormFileCollection files)
        {
            // Retrieves container name
            _blobContainerClient =  _blobServiceClient.GetBlobContainerClient(containerName);
            // Creates container if doesn't exist
            await _blobContainerClient.CreateIfNotExistsAsync();

            await _blobContainerClient.SetAccessPolicyAsync(PublicAccessType.BlobContainer);

            List<(string fileName, string pathOrContainerName)> datas = new();

            foreach (IFormFile file in files) 
            {
                string fileNewName = await FileRenameAsync(containerName, file.FileName, HasFile);
                // 
                BlobClient blobClient = _blobContainerClient.GetBlobClient(fileNewName);
                
                await blobClient.UploadAsync(file.OpenReadStream());
                datas.Add((fileNewName, $"{containerName}/{fileNewName}"));
            }

            return datas;
        }

    }
}

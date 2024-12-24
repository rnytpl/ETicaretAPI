using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using ETicaretAPI.Application.Abstractions.Storage.Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.Processing;


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
            var response = _blobContainerClient.DeleteBlob(blobName,DeleteSnapshotsOption.IncludeSnapshots);


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

        //public async Task<List<(string fileName, string pathOrContainerName)>> UploadAsync(string containerName, IFormFileCollection files)
        //{
        //    // Retrieves container name
        //    _blobContainerClient =  _blobServiceClient.GetBlobContainerClient(containerName);
        //    // Creates container if doesn't exist
        //    await _blobContainerClient.CreateIfNotExistsAsync();

        //    await _blobContainerClient.SetAccessPolicyAsync(PublicAccessType.BlobContainer);

        //    List<(string fileName, string pathOrContainerName)> datas = new();

        //    foreach (IFormFile file in files) 
        //    {
        //        string fileNewName = await FileRenameAsync(containerName, file.FileName, HasFile);
        //        // 
        //        BlobClient blobClient = _blobContainerClient.GetBlobClient(fileNewName);

        //        await blobClient.UploadAsync(file.OpenReadStream());
        //        datas.Add((fileNewName, $"{containerName}/{fileNewName}"));
        //    }

        //    return datas;
        //}

        public async Task<List<(string fileName, string pathOrContainerName)>> UploadAsync(string containerName, IFormFileCollection files)
        {
            // Retrieves container name
            _blobContainerClient = _blobServiceClient.GetBlobContainerClient(containerName);

            // Creates container if doesn't exist
            await _blobContainerClient.CreateIfNotExistsAsync();
            await _blobContainerClient.SetAccessPolicyAsync(PublicAccessType.BlobContainer);

            List<(string fileName, string pathOrContainerName)> datas = new();

            foreach (IFormFile file in files)
            {
                string fileNewName = await FileRenameAsync(containerName, file.FileName, HasFile);

                // Compress image
                using (var inputStream = file.OpenReadStream())
                {
                    using (var image = await Image.LoadAsync(inputStream)) // Load the image
                    {
                        // Resize or compress the image
                        image.Mutate(x => x.Resize(new ResizeOptions
                        {
                            Mode = ResizeMode.Max,
                            Size = new Size(1024, 768) // Adjust the size as needed
                        }));

                        // Set JPEG compression quality
                        var jpegOptions = new JpegEncoder
                        {
                            Quality = 75 // Set the quality (1-100). Adjust as per your need.
                        };

                        using (var outputStream = new MemoryStream())
                        {
                            await image.SaveAsync(outputStream, jpegOptions); // Save compressed image
                            outputStream.Position = 0; // Reset stream position

                            // Upload compressed image to Azure Blob Storage
                            BlobClient blobClient = _blobContainerClient.GetBlobClient(fileNewName);
                            await blobClient.UploadAsync(outputStream);
                        }
                    }
                }

                datas.Add((fileNewName, $"{containerName}/{fileNewName}"));
            }

            return datas;
        }

    }
}

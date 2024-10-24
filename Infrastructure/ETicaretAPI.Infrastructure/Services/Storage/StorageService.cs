using ETicaretAPI.Application.Abstractions.Storage;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Infrastructure.Services.Storage
{
    public class StorageService : IStorageService
    {

        readonly IStorage _storage;


        public StorageService(IStorage storage)
        {
            _storage = storage;
        }

        public string StorageName { get => _storage.GetType().Name; }

        public async Task DeleteAsync(string pathOrContainerName, string fileName) =>
            await _storage.DeleteAsync(pathOrContainerName, fileName);
        //await _storage.DeleteAsync(fileName);


        public List<string> GetFiles(string pathOrContainerName) => _storage.GetFiles(pathOrContainerName);

        public bool HasFile(string pathOrContainerName, string fileName) => _storage.HasFile(pathOrContainerName, fileName);

        /// <summary>
        /// Path or ContainerName parameters determines the location where the files should be stored.
        /// </summary>
        /// <param name="pathOrContainerName"></param>
        /// <param name="files"></param>
        /// <returns></returns>
        public Task<List<(string fileName, string pathOrContainerName)>> UploadAsync(string pathOrContainerName, IFormFileCollection files) => _storage.UploadAsync(pathOrContainerName, files);
    }
}

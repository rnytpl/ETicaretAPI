using ETicaretAPI.Application.Services;
using ETicaretAPI.Infrastructure.Operations;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Infrastructure.Services
{
    public class FileService : IFileService
    {

        readonly private IWebHostEnvironment _webHostEnvironment;
        public FileService(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<bool> CopyFileAsync(string path, IFormFile file)
        {

            try
            {
                await using FileStream stream = new(path, FileMode.Create, FileAccess.Write, FileShare.None, 1024 * 1024, useAsync: false);

                await file.CopyToAsync(stream);
                await stream.FlushAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            

        }
        /// <summary>
        /// Get the file extension
        /// Retrieve file name without extension
        /// Rename the filename appropriately using CharacterRegulatory method from NameOperation class
        /// Check if the newly renamed file exists in directory
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        async Task<string> FileRenameAsync(string uploadPath, string fileName)
        {
                string extension = Path.GetExtension(fileName);
                string oldName = Path.GetFileNameWithoutExtension(fileName);
                // Without extension
                string regulatedName = $"{NameOperation.CharacterRegulatory(oldName)}";
                string newFileName = $"{regulatedName}{extension}";

            try

            {

                if (
                    await Task.Run(
                        () => !File.Exists(Path.Combine(uploadPath, newFileName))
                    )
                )
                {
                    return newFileName;
                } 


                int iteration = 1;

                    while (
                        await Task.Run(
                            () => File.Exists(Path.Combine(uploadPath, newFileName))
                        )
                    )
                    {
                        newFileName = $"{regulatedName} - ({iteration}){extension}";
                        iteration++;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("An unexpected error occured while renaming the file");
                }

            return newFileName;
        }

        /// <summary>
        /// Receive path to create directory
        /// Check if directory exists, create if not
        /// Iterate over each uploaded file
        /// Pass file name to FileRenameAsync to rename the file appropriately
        /// Copy the file to directory with 
        /// </summary>
        /// <param name="path"></param>
        /// <param name="files"></param>
        /// <returns></returns>
        public async Task<List<(string fileName, string path)>> UploadAsync(string path, IFormFileCollection files)
        {
            
            string uploadPath = Path.Combine(_webHostEnvironment.WebRootPath, path);

            if (!File.Exists(uploadPath))
            {
                Directory.CreateDirectory(uploadPath);
            }

            List<(string fileName, string path)> datas = new();

            List<bool> results = new();

            foreach (IFormFile file in files)
            {
                // Returns file name and extension of a file path
                string newFileName = await FileRenameAsync(uploadPath, file.FileName);

                bool result = await CopyFileAsync($"{uploadPath}\\{newFileName}", file);
                datas.Add((newFileName, $"{uploadPath}\\{newFileName}"));
                results.Add(result);
            }

            if (results.TrueForAll(r => r.Equals(true))) 
                return datas;

            //todo 
            return datas;

        }
    }
}

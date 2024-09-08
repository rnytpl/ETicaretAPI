using ETicaretAPI.Infrastructure.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Infrastructure.Services.Storage
{
    public class Storage
    {

        protected delegate bool HasFile(string pathOrContainerNameName, string fileName);
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
        protected async Task<string> FileRenameAsync(string pathOrContainerName, string fileName, HasFile hasFileMethod)
        {
            string extension = Path.GetExtension(fileName);
            string oldName = Path.GetFileNameWithoutExtension(fileName);
            // Without extension
            string regulatedName = $"{NameOperation.CharacterRegulatory(oldName)}";
            string newFileName = $"{regulatedName}{extension}";

            try

            {
                var result = hasFileMethod(pathOrContainerName, newFileName);


                if (
                    !hasFileMethod(pathOrContainerName, newFileName)
                    )
                {
                    return newFileName;
                }


                int iteration = 1;

                while (
                    hasFileMethod(pathOrContainerName, newFileName)

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
    } 
}

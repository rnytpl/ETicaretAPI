using ETicaretAPI.Infrastructure.Operations;

namespace ETicaretAPI.Infrastructure.Services
{
    public class FileService
    {



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


    }
}

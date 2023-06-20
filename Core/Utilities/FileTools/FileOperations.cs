using Microsoft.AspNetCore.Http;

namespace Core.Utilities.FileTools
{
    public class FileOperations
    {
        public async static Task<string> UploadAsync(IFormFile file, string uploadPath)
        {
            try
            {
                var resource = Directory.GetCurrentDirectory();

                var extension = Path.GetExtension(file.FileName);
                var imageName = Guid.NewGuid() + extension;

                var saveFolder = Path.Combine(resource, uploadPath);
                var fullPath = Path.Combine(saveFolder, imageName);



                if (!Directory.Exists(saveFolder))
                {
                    Directory.CreateDirectory(saveFolder);
                }


                var stream = new FileStream(fullPath, FileMode.Create);
                await file.CopyToAsync(stream);

                return uploadPath + "/" + imageName;
            }
            catch (Exception e)
            {

                throw e;
            }


        }

        public async static Task DeleteAsync(string filePath)
        {

            try
            {
                var DeletePath = Directory.GetCurrentDirectory() + "/" + filePath;

                if (File.Exists(DeletePath))
                {
                    File.Delete(DeletePath);
                }
            }
            catch (Exception e)
            {

                throw e;
            }
           
        }
    }
}

using Newtonsoft.Json.Linq;
using NuGet.Packaging.Signing;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

namespace Blog.Helpers
{
    public static class FileExtension
    {
        public static bool IsValidSize(this IFormFile file, float kb = 30) => file.Length <= kb * 1024;
        //public static string IsCorrectType(this IFormFile file, string correntType = "image") => file.FileName.ContentType = correntType;

        public async static Task<string> SaveAsync(this IFormFile file, string path)
        {
            string extension = Path.GetExtension(file.FileName);
            string fileNName = Path.GetFileName(file.Name).Length > 32 ?
                file.FileName.Substring(0, 32) :
                Path.GetFileName(file.FileName);
            var filePath = Path.Combine(Path.GetRandomFileName()+fileNName+extension);
            using (FileStream fs=File.Create(Path.Combine(PathContains.RootPatg, filePath)))
            {
                await file.CopyToAsync(fs);
            }
            return fileNName;
        }
    }
}

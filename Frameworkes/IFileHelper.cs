using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frameworks
{
    public interface IFileHelper
    {
        Task<string> SingleUploader(IFormFile file,string part, string folder);
        Task<List<string>> CourseUploader(List<IFormFile> files, string folder);
        Task DeleteFile(string filePath);
        Task DeleteDirectory(string filePath);
        bool CheckDeirectory(string filePath);
        Task ReplaceFile(string originalFile, string FileToReplace);
    }
}

using Frameworks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Hofre.HostFrameworks
{
    public class FileHelper : IFileHelper
    {
        private readonly IWebHostEnvironment _env;
        private string filename;
        private List<string> filenames;

        public FileHelper(IWebHostEnvironment env)
        {
            _env = env;
            filenames = new List<string>();
        }

        public async Task<string> SingleUploader(IFormFile file, string part, string folder)
        {
            if (file == null) return string.Empty;

            await Task.Run(() =>
            {
                var filepath = $"{_env.WebRootPath}//Media//{part}//{folder}";
                if (!Directory.Exists(filepath))
                {
                    Directory.CreateDirectory(filepath);
                }
                filename = file.FileName;
                var pathfile = $"{filepath}//{filename}";
                using (var stram = File.Create(pathfile))
                {
                    file.CopyTo(stram);
                }
            });
            return filename;
        }

        public async Task<List<string>> CourseUploader(List<IFormFile> files, string folder)
        {
            if (files == null) return new();

            await Task.Run(() =>
            {
                var filepath = $"{_env.WebRootPath}//Media//Course//{folder}";
                if (!Directory.Exists(filepath))
                {
                    Directory.CreateDirectory(filepath);
                }
                foreach (var file in files)
                {
                    filenames.Add($"{file.FileName}");
                    var pathfile = $"{filepath}//{file.FileName}";
                    using (var stram = File.Create(pathfile))
                    {
                        file.CopyTo(stram);
                    }

                }
            });

            return filenames;
        }

        public async Task DeleteFile(string filePath)
        {
            await Task.Run(() =>
            {
                if (File.Exists(Path.Combine($"{_env.WebRootPath}/{filePath}")))
                {
                    File.Delete(Path.Combine($"{_env.WebRootPath}/{filePath}"));

                }
               
            });
        }

        public async Task DeleteDirectory(string filePath)
        {
            await Task.Run(() =>
            {
                if (Directory.Exists(Path.Combine(filePath)))
                    Directory.Delete(Path.Combine(filePath),true);
            });
        }

        public bool CheckDeirectory(string filePath)
        {

            if (Directory.Exists(Path.Combine(filePath)))
                return true;
            else
                return false;

        }

        public async Task ReplaceFile(string originalFile, string FileToReplace)
        {
            await Task.Run(() =>
            {
                File.Move(originalFile, FileToReplace);

            });
        }
    }
}

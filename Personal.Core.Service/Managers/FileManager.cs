using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.FileProviders;
using Personal.Core.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal.Core.Service.Managers
{
    public class FileManager : IFileService
    {
        private readonly IFileProvider _fileProvider;

        public FileManager(IFileProvider fileProvider)
        {
            _fileProvider = fileProvider;
        }

        public async Task<byte[]> ExportResumeAsync(string folderName, string fileName)
        {
            var filePath = _fileProvider.GetDirectoryContents(folderName);
            var file = await File.ReadAllBytesAsync(filePath.First(x => x.Name == fileName).PhysicalPath);
            return file;
        }

        public async Task<string> UploadImageAsync(string fileNameWithExtension, IFormFile file)
        {
            var wwwrootFolder = _fileProvider.GetDirectoryContents("wwwroot");
            var randomFileName = $"{Guid.NewGuid()}{Path.GetExtension(fileNameWithExtension)}";
            var newPicturePath = Path.Combine(wwwrootFolder.First(b => b.Name == "Images").PhysicalPath, randomFileName);
            using var stream = new FileStream(newPicturePath, FileMode.Create);
            await file.CopyToAsync(stream);
            return randomFileName;
        }
    }


}

using Microsoft.Extensions.FileProviders;
using Personal.Core.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal.Core.Service.Managers
{
    public class PdfManager : IPdfService
    {
        private readonly IFileProvider _fileProvider;

        public PdfManager(IFileProvider fileProvider)
        {
            _fileProvider = fileProvider;
        }

        public async Task<byte[]> ExportResumeAsync(string folderName, string fileName)
        {
            var filePath = _fileProvider.GetDirectoryContents(folderName);
            var file = await File.ReadAllBytesAsync(filePath.First(x => x.Name == fileName).PhysicalPath);
            return file;
        }
    }


}

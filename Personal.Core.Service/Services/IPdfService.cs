using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal.Core.Service.Services
{
    public interface IPdfService
    {
        Task<byte[]> ExportResumeAsync(string folderName, string fileName);
    }
}

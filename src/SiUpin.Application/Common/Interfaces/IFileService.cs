using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using SiUpin.Application.Common.Interfaces.Files;

namespace SiUpin.Application.Common.Interfaces
{
    public interface IFileService
    {
        T ReadJSONFile<T>(string filePath);
        Task<ProcessFileResult> ProcessFile(IFormFile formFile);
        Task<SaveFileResult> SaveFile(IList<byte> fileContent, string folderPath, string fileName);
        Task<RemoveFileResult> RemoveFile(string folderPath, string fileName);
    }
}
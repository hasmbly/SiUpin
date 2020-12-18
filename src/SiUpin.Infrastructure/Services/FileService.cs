using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using SiUpin.Application.Common.Interfaces;
using SiUpin.Application.Common.Interfaces.Files;
using SiUpin.Shared;

namespace SiUpin.Infrastructure.Services
{
    public class FileService : IFileService
    {
        private readonly IConfiguration _configuration;

        public FileService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public T ReadJSONFile<T>(string filePath)
        {
            var jsonString = System.IO.File.ReadAllText(filePath, Encoding.UTF8);

            return JsonConvert.DeserializeObject<T>(jsonString);
        }

        public async Task<ProcessFileResult> ProcessFile(IFormFile formFile)
        {
            var result = new ProcessFileResult();

            var options = _configuration.GetSection(SiUpinOptions.RootSection).Get<SiUpinOptions>();

            var fileName = WebUtility.HtmlEncode(formFile.FileName);

            if (formFile.Length > options.FileSizeLimit)
            {
                result.ErrorMessage = $"File {fileName} is too large.";
            }
            else
            {
                try
                {
                    using var memoryStream = new MemoryStream();
                    await formFile.CopyToAsync(memoryStream);

                    if (memoryStream.Length > 0)
                    {
                        result.IsSuccessful = true;
                        result.FileContent = memoryStream.ToArray();
                    }
                    else
                    {
                        result.ErrorMessage = $"File {fileName} is empty.";
                    }
                }
                catch
                {
                    result.ErrorMessage = $"Failed to process File: {fileName}";
                }
            }

            return result;
        }

        public async Task<SaveFileResult> SaveFile(IList<byte> fileContent, string folderPath, string fileName)
        {
            var result = new SaveFileResult();

            try
            {
                Directory.CreateDirectory(folderPath);
                var filePath = Path.Combine(folderPath, fileName);

                using var fileStream = System.IO.File.Create(filePath);
                await fileStream.WriteAsync(fileContent.ToArray());

                result.IsSuccessful = true;
            }
            catch
            {
                result.ErrorMessage = $"Failed to upload Project Document {fileName}";
            }

            return result;
        }

        public async Task<RemoveFileResult> RemoveFile(string folderPath, string fileName)
        {
            var result = new RemoveFileResult();

            var filePath = Path.Combine(folderPath, fileName);

            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
                result.IsSuccessful = true;
            }

            return await Task.FromResult(result);
        }
    }
}
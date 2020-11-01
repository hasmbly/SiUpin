using System.Text;
using Newtonsoft.Json;
using SiUpin.Application.Common.Interfaces;

namespace SiUpin.Infrastructure.Services
{
    public class FileService : IFileService
    {
        public T ReadJSONFile<T>(string filePath)
        {
            var jsonString = System.IO.File.ReadAllText(filePath, Encoding.UTF8);

            return JsonConvert.DeserializeObject<T>(jsonString);
        }
    }
}
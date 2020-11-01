namespace SiUpin.Application.Common.Interfaces
{
    public interface IFileService
    {
        T ReadJSONFile<T>(string filePath);
    }
}
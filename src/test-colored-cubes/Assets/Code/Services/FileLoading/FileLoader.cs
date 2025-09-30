using System.IO;

namespace Code.Services.FileLoading
{
    public class FileLoader : IFileLoader
    {
        public string[] LoadFromDisk(string path)
        {
            return File.ReadAllLines(path);
        }
    }
}

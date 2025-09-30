namespace Code.Services.FileLoading
{
    public interface IFileLoader
    {
        string[] LoadFromDisk(string path);
    }
}
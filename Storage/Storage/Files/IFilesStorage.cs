using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.Storage;

namespace Storage.Files
{
    public interface IFilesStorage
    {
        Task<bool> CreateFileAsync(StorageFile file, StorageFolder folder = null);
        Task<bool> DeleteFileAsync(string fileName, StorageFolder folder = null);
        Task<bool> FileExistsAsync(string fileName, StorageFolder folder = null);
        Task<IReadOnlyList<StorageFile>> GetFilesAsync(StorageFolder folder = null);
        Task<List<string>> GetFilesNameAsync(StorageFolder folder = null);
    }
}
namespace Storage.Folders
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Windows.Storage;

    public interface IFolderStorage
    {
        Task<bool> FolderExistsAsync(string folderName, StorageFolder folder = null);
        Task<StorageFolder> GetFolderAsync(string folderName, StorageFolder folder = null);
        Task<IReadOnlyList<StorageFolder>> GetFoldersAsync(StorageFolder folder = null);
    }
}
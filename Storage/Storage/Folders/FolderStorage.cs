namespace Storage.Folders
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Windows.Storage;

    public class FolderStorage : IFolderStorage
    {
        private StorageFolder _appFolder = ApplicationData.Current.LocalFolder;
        public async Task<bool> FolderExistsAsync(string folderName, StorageFolder folder = null)
        {
            StorageFolder storageFolder = folder == null ? _appFolder : folder;
            StorageFolder selectedFolder = null;
            try
            {
                selectedFolder = await storageFolder.GetFolderAsync(folderName);
            }
            catch (Exception exception)
            {
                System.Diagnostics.Debug.WriteLine($"[PatternLock] Exception FolderExistsAsync => {exception.Message}");
                return false;
            }
            return true;
        }

        public async Task<StorageFolder> GetFolderAsync(string folderName, StorageFolder folder = null)
        {
            var storageFolder = folder == null ? _appFolder : folder;
            StorageFolder selectedFolder = null;
            try
            {
                selectedFolder = await storageFolder.GetFolderAsync(folderName);
            }
            catch (Exception exception)
            {
                System.Diagnostics.Debug.WriteLine($"[PatternLock] Exception GetFolderAsync => {exception.Message}");
            }
            return selectedFolder;
        }

        public async Task<IReadOnlyList<StorageFolder>> GetFoldersAsync(StorageFolder folder = null)
        {
            var storageFolder = folder == null ? _appFolder : folder;
            IReadOnlyList<StorageFolder> folders = null;

            try
            {
                folders = await storageFolder.GetFoldersAsync();
            }
            catch (Exception exception)
            {
                System.Diagnostics.Debug.WriteLine($"[PatternLock] Exception GetFoldersAsync => {exception.Message}");
            }
            return folders;
        }
    }
}
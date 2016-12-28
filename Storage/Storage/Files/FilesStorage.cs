namespace Storage.Files
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Windows.Storage;

    public class FilesStorage : IFilesStorage
    {
        private StorageFolder _appFolder = ApplicationData.Current.LocalFolder;

        public async Task<bool> CreateFileAsync(StorageFile file, StorageFolder folder = null)
        {
            StorageFile storageFile = null;
            StorageFolder storageFolder = null;
            try
            {
                storageFolder = folder == null ? _appFolder : folder;
                storageFile = await file.CopyAsync(storageFolder, file.Name, NameCollisionOption.ReplaceExisting);
            }
            catch (Exception exception)
            {
                System.Diagnostics.Debug.WriteLine($"[PatternLock] Exception CreateFileAsync => {exception.Message}");
                storageFile = null;
            }
            return storageFile != null ? true : false;
        }

        public async Task<bool> DeleteFileAsync(string fileName, StorageFolder folder = null)
        {
            try
            {
                StorageFolder storageFolder = folder == null ? _appFolder : folder;
                StorageFile storageFile = await storageFolder.GetFileAsync(fileName);
                await storageFile.DeleteAsync(StorageDeleteOption.PermanentDelete);
                return true;
            }
            catch (Exception exception)
            {
                System.Diagnostics.Debug.WriteLine($"[PatternLock] Exception DeleteFileAsync => {exception.Message}");
                return false;
            }
        }

        public async Task<bool> FileExistsAsync(string fileName, StorageFolder folder = null)
        {
            StorageFolder storageFolder = folder == null ? _appFolder : folder;

            try
            {
                StorageFile file = await storageFolder.GetFileAsync(fileName);
            }
            catch (Exception exception)
            {
                System.Diagnostics.Debug.WriteLine($"[PatternLock] Exception FileExistsAsync => {exception.Message}");
                return false;
            }
            return true;
        }

        public async Task<IReadOnlyList<StorageFile>> GetFilesAsync(StorageFolder folder = null)
        {
            StorageFolder storageFolder = folder == null ? _appFolder : folder;
            return await storageFolder.GetFilesAsync();
        }

        public async Task<List<string>> GetFilesNameAsync(StorageFolder folder = null)
        {
            StorageFolder storageFolder = folder == null ? _appFolder : folder;
            var files = new List<string>();
            IReadOnlyList<StorageFile> storageFiles = await storageFolder.GetFilesAsync();
            foreach (var file in storageFiles)
            {
                files.Add(file.Name);
            }
            return files;
        }
    }
}
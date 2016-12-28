namespace Storage.Settings
{
    using System;
    using Windows.Storage;

    public class LocalSetting : ISetting
    {
        private StorageFolder _appFolder = ApplicationData.Current.LocalFolder;
        private ApplicationDataContainer _localSettings = ApplicationData.Current.LocalSettings;
        public string GetSetting(string key)
        {
            return ExistsSetting(key) ? _localSettings.Values[key].ToString() : "";
        }

        public void AddSetting(string key, string data)
        {
            _localSettings.Values[key] = data;
        }

        public bool DeleteSetting(string key)
        {
            if (ExistsSetting(key))
            {
                return _localSettings.Values.Remove(key);
            }
            else
            {
                throw new NullReferenceException("La clave no existe | Key don't found");
            }
        }

        public bool ExistsSetting(string key)
        {
            return _localSettings.Values.ContainsKey(key);
        }
    }
}
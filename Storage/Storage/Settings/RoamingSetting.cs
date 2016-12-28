namespace Storage.Settings
{
    using System;
    using Windows.Storage;

    public class RoamingSetting : ISetting
    {
        private StorageFolder _appFolder = ApplicationData.Current.LocalFolder;
        private ApplicationDataContainer _roamingSettings = ApplicationData.Current.RoamingSettings;


        public string GetSetting(string key)
        {
            return ExistsSetting(key) ? _roamingSettings.Values[key].ToString() : "";
        }

        public void AddSetting(string key, string data)
        {
            _roamingSettings.Values[key] = data;
        }

        public bool DeleteSetting(string key)
        {
            if (ExistsSetting(key))
            {
                return _roamingSettings.Values.Remove(key);
            }
            else
            {
                throw new NullReferenceException("La clave no existe | Key don't found");
            }
        }

        public bool ExistsSetting(string key)
        {
            return _roamingSettings.Values.ContainsKey(key);
        }
    }
}
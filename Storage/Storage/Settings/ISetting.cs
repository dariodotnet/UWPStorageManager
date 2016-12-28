namespace Storage.Settings
{
    public interface ISetting
    {
        string GetSetting(string key);
        void AddSetting(string key, string data);
        bool DeleteSetting(string key);
        bool ExistsSetting(string key);
    }
}
using System;

namespace UserSettings.Exceptions
{
    public class SettingKeyNotFoundExcetion : Exception
    {
        public SettingKeyNotFoundExcetion(string key) : base($"{key} not found in settings table")
        {

        }
    }
}

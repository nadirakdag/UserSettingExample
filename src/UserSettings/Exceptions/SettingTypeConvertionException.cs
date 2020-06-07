using System;

namespace UserSettings.Exceptions
{
    public class SettingTypeConvertionException : Exception
    {
        public SettingTypeConvertionException(string key, Type type) : base($"Type Convertion Error, Type: {type.Name}, SettingKey: {key}")
        {

        }
    }
}

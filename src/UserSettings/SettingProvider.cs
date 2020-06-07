using Core.Domain;
using Core.Interfaces;
using System;
using System.Threading.Tasks;
using UserSettings.Exceptions;
using UserSettings.Interfaces;

namespace UserSettings
{
    public class SettingProvider : ISettingProvider
    {
        private readonly ISettingDbContext _settingDbContext;

        public SettingProvider(ISettingDbContext settingDbContext)
        {
            _settingDbContext = settingDbContext;
        }

        public T GetSettingValue<T>(string key)
        {
            var result = _settingDbContext.Settings.Find(key);
            return ConvertToType<T>(key, result);
        }

        private static T ConvertToType<T>(string key, Setting result)
        {
            if (result == null)
            {
                throw new SettingKeyNotFoundExcetion(key);
            }

            try
            {
                return (T)Convert.ChangeType(result.Value, typeof(T));
            }
            catch
            {
                throw new SettingTypeConvertionException(key, typeof(T));
            }
        }

        public async Task<T> GetSettingValueAsync<T>(string key)
        {
            var result = await _settingDbContext.Settings.FindAsync(key);
            return ConvertToType<T>(key, result);
        }

        public async Task<bool> SetSettingValueAsync<T>(string key, T value)
        {
            _settingDbContext.Settings.Add(new Setting { Key = key, Value = value.ToString() });
            var result = await _settingDbContext.SaveChangesAsync();
            return result > 0;
        }
    }
}

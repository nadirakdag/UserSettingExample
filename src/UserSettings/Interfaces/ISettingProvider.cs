using System.Threading.Tasks;

namespace UserSettings.Interfaces
{
    public interface ISettingProvider
    {
        T GetSettingValue<T>(string key);
        Task<T> GetSettingValueAsync<T>(string key);
        Task<bool> SetSettingValueAsync<T>(string key, T value);
    }
}

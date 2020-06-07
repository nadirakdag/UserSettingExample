using System;
using UserSettings.Interfaces;

namespace UserSettings
{
    public class UserSettingCustom : IUserSettings
    {

        private readonly ISettingProvider _settingProvider;

        public UserSettingCustom(ISettingProvider settingProvider)
        {
            _settingProvider = settingProvider;
        }

        public string UserTimeZone => _settingProvider.GetSettingValue<string>(nameof(UserTimeZone));

        public DateTime UserDefaultTime => _settingProvider.GetSettingValue<DateTime>(nameof(UserDefaultTime));

    }
}

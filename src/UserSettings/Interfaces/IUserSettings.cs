using System;

namespace UserSettings.Interfaces
{
    public interface IUserSettings
    {
        string UserTimeZone { get; }
        DateTime UserDefaultTime { get; }
    }
}

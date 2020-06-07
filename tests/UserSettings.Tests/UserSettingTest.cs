using Shouldly;
using System;
using UserSettings.Interfaces;
using Xunit;

namespace UserSettings.Tests
{
    public class UserSettingTest : IClassFixture<DatabaseFixture>
    {
        IUserSettings _userSetting;

        public UserSettingTest(DatabaseFixture databaseFixture)
        {
            var _settingProvider = new SettingProvider(databaseFixture.SettingDbContext);
            _userSetting = new UserSettingCustom(_settingProvider);
        }

        [Fact]
        public void When_Called_UserSetting_UserTimeZone_Should_Return_TimezoneName()
        {
            _userSetting.UserTimeZone.ShouldBe("Europe/Istanbul");
        }

        [Fact]
        public void When_Called_UserSetting_UserDefaultTime_Should_Return_DefaultDate()
        {
            _userSetting.UserDefaultTime.ShouldBe(DateTime.Parse("6/7/2020 11:11:09 AM"));
        }
    }
}

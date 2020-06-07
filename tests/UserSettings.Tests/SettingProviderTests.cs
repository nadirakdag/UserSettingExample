using Shouldly;
using System;
using System.Threading.Tasks;
using Xunit;
using UserSettings.Interfaces;
using UserSettings.Exceptions;

namespace UserSettings.Tests
{
    public class SettingProviderTests : IClassFixture<DatabaseFixture>
    {
        ISettingProvider _settingProvider;

        public SettingProviderTests(DatabaseFixture databaseFixture)
        {
            _settingProvider = new SettingProvider(databaseFixture.SettingDbContext);
        }

        [Fact]
        public async Task Given_SettingKey_When_GetSettingValueAsync_Then_Return_SettingValue()
        {
            var value = await _settingProvider.GetSettingValueAsync<string>(key: "UserTimeZone");
            value.ShouldBeOfType<string>();
            value.ShouldBe("Europe/Istanbul");
        }

        [Fact]
        public async Task Given_SettingKey_When_GetSettingValueAsync_Then_Return_SameTypeOfSetting()
        {
            var value = await _settingProvider.GetSettingValueAsync<DateTime>(key: "UserDefaultTime");


            value.ShouldBeOfType<DateTime>();
            value.ShouldBe(DateTime.Parse("6/7/2020 11:11:09 AM"));
        }

        [Fact]
        public async Task Given_Invalid_SettingKey_When_GetSettingValueAsync_Then_Throw_SettingKeyNotFoundException()
        {
            await Should.ThrowAsync<SettingKeyNotFoundExcetion>(async () =>
             {
                 var value = await _settingProvider.GetSettingValueAsync<string>(key: "UserTimeZone2");
             });
        }

        [Fact]
        public async Task Given_Invalid_Type_When_GetSettingValueAsync_Then_Throw_SettingTypeConvertionException()
        {
            await Should.ThrowAsync<SettingTypeConvertionException>(async () =>
            {
                var value = await _settingProvider.GetSettingValueAsync<DateTime>(key: "UserTimeZone");
            });
        }

        [Fact]
        public async Task Given_SettingKey_And_Value_When_SetSettingValueAsync_Then_Return_True()
        {
            bool value = await _settingProvider.SetSettingValueAsync<string>(key: "UserTestSettingKey", value: "");

            value.ShouldBe(true);
        }

    }
}

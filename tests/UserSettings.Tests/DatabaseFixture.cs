using Core.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;

namespace UserSettings.Tests
{
    public class DatabaseFixture : IDisposable
    {
        public SettingDbContext SettingDbContext { get; private set; }

        public DatabaseFixture()
        {
            var options = new DbContextOptionsBuilder()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            SettingDbContext = new SettingDbContext(options);
            SettingDbContext.Database.EnsureCreated();

            SettingDbContext.Settings.Add(new Core.Domain.Setting { Key = "UserTimeZone", Value = "Europe/Istanbul" });
            SettingDbContext.Settings.Add(new Core.Domain.Setting { Key = "UserDefaultTime", Value = "6/7/2020 11:11:09 AM" });
            SettingDbContext.SaveChangesAsync();
        }


        public void Dispose()
        {
            SettingDbContext.Database.EnsureDeleted();
            SettingDbContext.Dispose();
        }
    }
}

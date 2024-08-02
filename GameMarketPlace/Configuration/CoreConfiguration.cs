using Configuration.Models.Options;
using Core.Utilities.ServiceTools;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IO = System.IO;

namespace Configuration
{
    public static class CoreConfiguration
    {
        readonly static IConfigurationRoot Configuration;
        static CoreConfiguration()
        {
            Configuration = new ConfigurationBuilder()
                                .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", optional: true, reloadOnChange: true)
                                .Build();
        }

        public static string ConnectionString { get => Configuration.GetConnectionString("DbConnectionString"); }
        public static EmailOptions EmailOptions { get => Configuration.GetSection("EmailOptions").Get<EmailOptions>(); }
        public static TokenOptions TokenOptions { get => Configuration.GetSection("TokenOptions").Get<TokenOptions>(); }
        public static FileOptions FileOptions { get => Configuration.GetSection("FileOptions").Get<FileOptions>(); }
        public static APIOptions APIOptions { get => Configuration.GetSection("APIOptions").Get<APIOptions>(); }
        public static MassTransitOptions MassTransitOptions { get => Configuration.GetSection("MassTransitOptions").Get<MassTransitOptions>(); }
        public static GoogleCloudOptions GoogleCloudOptions { get => Configuration.GetSection("GoogleCloudOptions").Get<GoogleCloudOptions>(); }

        #region Silinecek
        public static string ODataApiUrl { get => "https://localhost:7227/odata"; }
        public static string WebApiUrl { get => "https://localhost:7184/webapi"; }
        public static string RootPath { get => "C:\\Users\\sandi\\source\\repos\\GameMarketPlace\\GameStore.Shared"; }

        #endregion
    }
}

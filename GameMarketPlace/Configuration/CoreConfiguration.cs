using Core.Entities.DTO.Options;
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
                                .AddJsonFile("coresettings.json", optional: true, reloadOnChange: true)
                                .Build();
        }

        public static string ConnectionString { get => Configuration.GetConnectionString("DbConnectionString"); }
        public static string ODataApiUrl { get => Configuration.GetSection("ODataApiUrl").Value; }
        public static EmailOptions EmailOptions { get => Configuration.GetSection("EmailOptions").Get<EmailOptions>(); }
        public static TokenOptions TokenOptions { get => Configuration.GetSection("TokenOptions").Get<TokenOptions>(); }
        public static FileOptions FileOptions { get => Configuration.GetSection("FileOptions").Get<FileOptions>(); }
        public static APIOptions APIOptions { get => Configuration.GetSection("APIOptions").Get<APIOptions>(); }
    }
}

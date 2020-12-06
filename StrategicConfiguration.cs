using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace StrategicData
{
    public class StrategicConfiguration
    {
        public IConfigurationRoot Configuration { get; }

        public StrategicConfiguration()
        {
            var builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json");

            Configuration = builder.Build();

            Console.WriteLine($"configuration: {Configuration.GetConnectionString("sqlserver")}");
        }

        public void ReadConfiguration()
        {
            // 
        }

    }
}

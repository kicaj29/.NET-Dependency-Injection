using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicrosoftDIhostedService472
{
    class Program
    {
        private static ILoggerFactory _loggerFactory;
        static async Task Main(string[] args)
        {
            _ = new LoggerConfiguration().WriteTo.Console();
            /*_loggerFactory = LoggerFactory.Create(loggerFactory =>
            {
                loggerFactory.AddSerilog();
            });*/


            using (IHost host = CreateHostBuilder(args).Build())
            {
                using (_ = host.Services.CreateScope())
                {
                    await host.RunAsync();
                }

            }
            Console.WriteLine("Initialization done");
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseSerilog()
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddSingleton<IRecognitionManager, RecognitionManager>();
                    services.AddHostedService<RecognitionMicroService>();
                    services.Configure<RecognitionSettings>((RecognitionSettings settings) =>
                    {
                        // Options pattern: https://docs.microsoft.com/en-us/aspnet/core/fundamentals/configuration/options?view=aspnetcore-6.0
                        settings.Setting1 = GetConfigValue("Setting1");
                        settings.Setting2 = GetConfigValue("Setting2");
                    });
                });

        private static string GetConfigValue(string key)
        {
            // it is typical approach to allow overwrite configuration using environment variables
            string value = Environment.GetEnvironmentVariable(key);
            if (string.IsNullOrWhiteSpace(value))
            {
                value = System.Configuration.ConfigurationManager.AppSettings[key];
            }

            return value;
        }
    }
}

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
            LoggerConfiguration logConfig = new LoggerConfiguration().WriteTo.Console();
            // Do some configuration to see if it impacts log output
            logConfig.MinimumLevel.Is(Serilog.Events.LogEventLevel.Information);
            Log.Logger = logConfig.CreateLogger();

            // it looks that using _loggerFactory is not needed if the logger is always injected directly by DI
            /*_loggerFactory = LoggerFactory.Create(loggerFactory =>
            {
                loggerFactory.AddSerilog();
            });*/

            Console.WriteLine($"Log.Logger: {Log.Logger.GetHashCode()}");


            using (IHost host = CreateHostBuilder(args).Build())
            {
                Console.WriteLine($"Log.Logger: {Log.Logger.GetHashCode()}");
                using (_ = host.Services.CreateScope())
                {
                    Console.WriteLine("Starting...");
                    await host.RunAsync();
                    Console.WriteLine("END");
                }

            }

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseSerilog()
                // if we do not pass anything then static Serilog.Log is used.
                // I check hash code of the used instances and they are different but maybe
                // the do some cloning.
                // It looks that this is the case https://github.com/serilog/serilog-extensions-logging/blob/7141ae23125cbdb6b67df6f9aab1c42f1fa58366/src/Serilog.Extensions.Logging/Extensions/Logging/SerilogLogger.cs#L37
                // because they call Serilog.Log.Logger.ForContext
                // After checking that calling logConfig.MinimumLevel.Is(Serilog.Events.LogEventLevel.Error);
                // really impacts log output we can be sure that Serilog.Log is used.
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

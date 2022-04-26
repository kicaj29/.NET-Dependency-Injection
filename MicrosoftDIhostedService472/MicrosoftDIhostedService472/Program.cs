using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicrosoftDIhostedService472
{
    class Program
    {
        static async Task Main(string[] args)
        {
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
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddSingleton<IRecognitionManager, RecognitionManager>();
                    services.AddHostedService<RecognitionMicroService>();
                });
    }
}

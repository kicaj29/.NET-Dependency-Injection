using Microsoft.Extensions.DependencyInjection;
using MicrosoftDI.ResolveDepsConditionally;
using MicrosoftDI.ScopedVsTransient;
using System;
using System.Threading.Tasks;

namespace MicrosoftDI
{
    class Program
    {
        static void Main(string[] args)
        {
            //BasicExample();
            //ScopedVsTransient();
            ResolveConditionally();
        }

        static void BasicExample()
        {
            var collection = new ServiceCollection();

            collection.AddScoped<IDataAccess, DataAccess>();
            collection.AddScoped<IBusiness, Business>();
            collection.AddScoped<IUserInterface, UserInterface>();

            Console.WriteLine("Creating provider 1");
            var provider = collection.BuildServiceProvider();
            var dal = provider.GetService<IDataAccess>();
            var b = provider.GetService<IBusiness>();
            var ui = new UserInterface(b);
            ui.GetData();

            Console.WriteLine("Creating provider 2");
            var provider1 = collection.BuildServiceProvider();
            var dal1 = provider.GetService<IDataAccess>();
            var b1 = provider.GetService<IBusiness>();
            // NOTE: I could also register UserInterface in DI and take the instance from there
            var ui1 = new UserInterface(b);
            ui1.GetData();
        }

        static void ScopedVsTransient()
        {
            var collection = new ServiceCollection();
            collection.AddScoped<ScopedClass>();
            collection.AddTransient<TransientClass>();
            var provider = collection.BuildServiceProvider();

            Console.Clear();
            Parallel.For(1, 10, i =>
            {
                // different threads all the same time access the same instance of ScopedClass
                Console.WriteLine($"Scoped ID: {provider.GetService<ScopedClass>().GetHashCode().ToString()}");
                // TransientClass is every time a new instance
                Console.WriteLine($"Transient ID: {provider.GetService<TransientClass>().GetHashCode().ToString()}");
            });

            Console.WriteLine("Press a key");
            Console.ReadKey();
        }

        static void ResolveConditionally()
        {
            var collection = new ServiceCollection();
            collection.AddScoped<EuropeTaxCalculator>();
            collection.AddScoped<AustraliaTaxCalculator>();

            collection.AddScoped<Func<UserLocations, ITaxCalculator>>(
                serviceProvider => key =>
                {
                    switch (key)
                    {
                        case UserLocations.Australia:
                            return serviceProvider.GetService<AustraliaTaxCalculator>();
                        case UserLocations.Europe:
                            return serviceProvider.GetService<EuropeTaxCalculator>();
                        default:
                            return null;
                    }
                });

            collection.AddSingleton<Purchase>();
            var provider = collection.BuildServiceProvider();
            var purchase = provider.GetService<Purchase>();

            var total = purchase.CheckOut(UserLocations.Australia);

            Console.WriteLine(total);

            Console.ReadKey();
        }
    }
}

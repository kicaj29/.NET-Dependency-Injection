using MyLib;
using SharedKernel;
using System;

namespace StructureMap.NET5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var cont = Container.For<BasicScanning>();

            var allServices = cont.GetAllInstances<IService>();

            foreach(var i in allServices)
            {
                i.CallMe();
            }

            AppointmentConfirmedEvent e = new AppointmentConfirmedEvent();
            DomainEvents.Raise(e);

        }
    }
}

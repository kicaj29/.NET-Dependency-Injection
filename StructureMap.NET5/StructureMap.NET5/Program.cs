using MyLib;
using System;

namespace StructureMap.NET5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var cont = Container.For<BasicScanning>();

            var all = cont.GetAllInstances<IService>();

            foreach(var i in all)
            {
                i.CallMe();
            }

            
        }
    }
}

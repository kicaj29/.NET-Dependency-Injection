using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyLib;
using StructureMap;

namespace StructureMap.NET5
{
    public class BasicScanning : Registry
    {
        public BasicScanning()
        {
            Scan(scan =>
            {
                // 1. Declare which assemblies to scan
                scan.AssemblyContainingType<IService>();

                // 2. Built in registration conventions
                //scan.AddAllTypesOf<IService>().NameBy(x => x.Name.Replace("Service", ""));
                scan.AddAllTypesOf<IService>();
                scan.WithDefaultConventions();

            });

            //For<IService>().Use<Service>();
        }
    }
}

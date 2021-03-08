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
            /*Scan(_ =>
            {
                _.AddAllTypesOf(typeof(IService));
                _.WithDefaultConventions();
            });*/

            For<IService>().Use<Service>();
        }
    }
}

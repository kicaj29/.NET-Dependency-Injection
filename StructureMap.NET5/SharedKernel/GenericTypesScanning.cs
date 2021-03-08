using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using StructureMap;

namespace SharedKernel
{
    public class GenericTypesScanning : Registry
    {
        public GenericTypesScanning()
        {
            Scan(scan =>
            {
                // 1. Declare which assemblies to scan
                //scan.AssemblyContainingType(typeof(IHandle<>));
                //scan.Assembly(Assembly.LoadFrom("MyLib.dll"));
                scan.Assembly("MyLib");
                //scan.AssembliesFromApplicationBaseDirectory();

                // 2. Built in registration conventions
                scan.AddAllTypesOf(typeof(IHandle<>));
                scan.WithDefaultConventions();

            });


            //For(Type.GetType("SharedKernel.IHandle")).Use(Type.GetType("MyLib.EmailConfirmationHandler"));


        }
    }
}

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
                // scan.AddAllTypesOf(typeof(IHandle<>));

                // from the thread in https://stackoverflow.com/questions/66528541/structuremap-does-not-see-types-in-asp-net-core-net5?answertab=oldest#tab-top
                // I got info that for open types this method should be used but AddAllTypesOf also is working in this example
                scan.ConnectImplementationsToTypesClosing(typeof(IHandle<>));
                // scan.WithDefaultConventions();

            });


            //For(Type.GetType("SharedKernel.IHandle")).Use(Type.GetType("MyLib.EmailConfirmationHandler"));


        }
    }
}

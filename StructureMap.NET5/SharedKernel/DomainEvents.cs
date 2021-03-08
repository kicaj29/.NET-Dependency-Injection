using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StructureMap;

namespace SharedKernel
{
    public static class DomainEvents
    {
        public static IContainer Container { get; set; }

        static DomainEvents()
        {
            Container = StructureMap.Container.For<GenericTypesScanning>();
        }

        public static void Raise<T>(T args) where T : IDomainEvent
        {
            foreach (var handler in Container.GetAllInstances<IHandle<T>>())
            {
                handler.Handle(args);
            }
        }
     }
}

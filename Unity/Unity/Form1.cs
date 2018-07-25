using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Practices.Unity;

namespace Unity
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnGO_Click(object sender, EventArgs e)
        {
            IUnityContainer container = new UnityContainer();

            container.RegisterType<Service1>(new ContainerControlledLifetimeManager());
            container.RegisterType<Service2>(new ContainerControlledLifetimeManager());
            container.RegisterType<Service3>(new ContainerControlledLifetimeManager());

            IUnityContainer childCtr = container.CreateChildContainer();

            childCtr.RegisterType<Service3>(new ContainerControlledLifetimeManager());

            var service1 = container.Resolve<Service1>();
            service1.CallMe();

            var service2 = container.Resolve<Service2>();
            service2.CallMe();

            //resolving svc1 will not create new instance of svc3 even it was registered in the childCtr
            var svc1 = childCtr.Resolve<Service1>();
            svc1.CallMe();

            //but when we resolve directly svc3 then new instance is used!
            var svc3 = childCtr.Resolve<Service3>();
            svc1.CallMe();

            childCtr.Dispose();
        }

        private void btnGoHierarchical_Click(object sender, EventArgs e)
        {
            IUnityContainer container = new UnityContainer();

            container.RegisterType<Service1>(new HierarchicalLifetimeManager());
            container.RegisterType<Service2>(new HierarchicalLifetimeManager());
            container.RegisterType<Service3>(new HierarchicalLifetimeManager());

            //this aproach is used in WebApi3 - child container is created for every request
            IUnityContainer childCtr = container.CreateChildContainer();

            var service1 = container.Resolve<Service1>();
            service1.CallMe();

            var service2 = container.Resolve<Service2>();
            service2.CallMe();

            //new instance is created
            var svc1 = childCtr.Resolve<Service1>();
            svc1.CallMe();

            //new instance is not created because it was resolved already during resolving Service1 in the child container!
            var svc3 = childCtr.Resolve<Service3>();
            svc1.CallMe();

            childCtr.Dispose();
        }
    }
}

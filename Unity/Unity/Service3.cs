using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unity
{
    public class Service3 : IDisposable
    {
        public Service3()
        {
            Debug.WriteLine("Service3");
        }

        public void CallMe()
        {
            Debug.WriteLine("CallMe Service3");
        }

        public void Dispose()
        {
            Debug.WriteLine("Service3 - dispose");
        }
    }
}

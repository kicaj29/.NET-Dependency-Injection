using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Unity
{
    public class Service1 : IDisposable
    {
        private Service2 _svc2;

        public Service1(Service2 svc2)
        {
            Debug.WriteLine("Service1");
            this._svc2 = svc2;
        }

        public void CallMe()
        {
            Debug.WriteLine("CallMe Service1");
            this._svc2.CallMe();
        }

        public void Dispose()
        {
            Debug.WriteLine("Service1 - dispose");
        }
    }
}

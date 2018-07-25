using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unity
{
    public class Service2 : IDisposable
    {
        private Service3 _svc3;
        public Service2(Service3 svc3)
        {
            Debug.WriteLine("Service2");
            this._svc3 = svc3;
        }

        public void CallMe()
        {
            Debug.WriteLine("CallMe Service2");
            this._svc3.CallMe();
        }

        public void Dispose()
        {
            Debug.WriteLine("Service2 - dispose");
        }
    }
}

using System;

namespace MyLib
{
    public class Service : IService
    {
        public void CallMe()
        {
            Console.WriteLine("CallMe executed");
        }
    }
}

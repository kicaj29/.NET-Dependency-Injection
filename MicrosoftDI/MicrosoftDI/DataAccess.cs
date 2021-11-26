using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicrosoftDI
{
    public class DataAccess : IDataAccess
    {
        public DataAccess()
        {
            Console.WriteLine("DataAccess created " + DateTime.Now.ToString());
        }

        public void Store(string userName, string password)
        {
            // here we store user name and password hash in DB
        }
    }
}

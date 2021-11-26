using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicrosoftDI
{
    public class Business : IBusiness
    {
        private readonly IDataAccess _dataAccess;
        public Business(IDataAccess dataAccess)
        {
            Console.WriteLine("Business created " + DateTime.Now.ToString());
            this._dataAccess = dataAccess;
        }

        public void SignUp(string userName, string password)
        {
            // here for example we can add some validation


            this._dataAccess.Store(userName, password);
        }
    }
}

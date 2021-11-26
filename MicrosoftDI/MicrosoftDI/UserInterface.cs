using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicrosoftDI
{
    public class UserInterface : IUserInterface
    {
        private IBusiness _business;

        public UserInterface(IBusiness business)
        {
            Console.WriteLine("UserInterfaces created " + DateTime.Now.ToString());
            this._business = business;
        }

        public void GetData()
        {
            Console.WriteLine("Enter user name:");
            var userName = Console.ReadLine();

            Console.WriteLine("Enter password:");
            var password = Console.ReadLine();

            this._business.SignUp(userName, password);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicrosoftDI
{
    public interface IDataAccess
    {
        void Store(string userName, string password);
    }
}

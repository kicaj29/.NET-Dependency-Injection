using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicrosoftDI.ResolveDepsConditionally
{
    public class AustraliaTaxCalculator : ITaxCalculator
    {
        public int Calculate()
        {
            return 10;

        }
    }
}

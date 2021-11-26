using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicrosoftDI.ResolveDepsConditionally
{
    public class EuropeTaxCalculator : ITaxCalculator
    {
        public int Calculate()
        {
            return 20;
        }
    }
}

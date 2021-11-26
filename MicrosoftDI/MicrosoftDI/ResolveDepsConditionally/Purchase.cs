using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicrosoftDI.ResolveDepsConditionally
{
    public class Purchase
    {
        private readonly Func<UserLocations, ITaxCalculator> _accessor;
        public Purchase(Func<UserLocations, ITaxCalculator> accessor)
        {
            this._accessor = accessor;
        }

        public int CheckOut(UserLocations location)
        {
            var tax = this._accessor(location);
            var total = tax.Calculate() + 100;
            return total;
        }
    }
}

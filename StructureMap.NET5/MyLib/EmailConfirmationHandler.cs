using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedKernel;

namespace MyLib
{
    public class EmailConfirmationHandler: IHandle<AppointmentConfirmedEvent>
    {
        public void Handle(AppointmentConfirmedEvent appointmentConfirmedEvent)
        {
            // TBD
        }
    }
}

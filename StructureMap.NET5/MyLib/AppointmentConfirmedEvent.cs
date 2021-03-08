using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedKernel;

namespace MyLib
{
    public class AppointmentConfirmedEvent : IDomainEvent
    {
        public AppointmentConfirmedEvent()
        {
            this.DateTimeEventOccurred = DateTime.Now;
        }

        public string EventType { get { return "AppointmentConfirmedEvent"; } }

        public DateTime DateTimeEventOccurred { get; private set; }
    }
}

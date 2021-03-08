using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedKernel
{
    public interface IApplicationEvent : IDomainEvent
    {
        string EventType { get; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TriNguyen.AtmSimulation.SharedKernel.Interfaces
{
    public interface IDomainEventDispatcher
    {
        Task Dispatch(BaseDomainEvent domainEvent);
    }
}

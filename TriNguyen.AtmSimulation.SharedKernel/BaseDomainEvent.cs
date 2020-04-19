using System;
using System.Collections.Generic;
using System.Text;

namespace TriNguyen.AtmSimulation.SharedKernel
{
    public abstract class BaseDomainEvent
    {
        public DateTime DateOccurred { get; protected set; } = DateTime.UtcNow;
    }
}

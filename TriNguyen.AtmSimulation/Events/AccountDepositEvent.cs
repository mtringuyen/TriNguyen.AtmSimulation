using System;
using System.Collections.Generic;
using System.Text;
using TriNguyen.AtmSimulation.Core.Entities;
using TriNguyen.AtmSimulation.SharedKernel;

namespace TriNguyen.AtmSimulation.Core.Events
{
    public class AccountDepositEvent : BaseDomainEvent
    {
        public Account CompletedItem { get; set; }

        public AccountDepositEvent(Account completedItem)
        {
            CompletedItem = completedItem;
        }
    }
}

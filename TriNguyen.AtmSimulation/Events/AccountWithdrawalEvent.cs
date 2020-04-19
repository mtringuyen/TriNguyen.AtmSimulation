using System;
using System.Collections.Generic;
using System.Text;
using TriNguyen.AtmSimulation.Core.Entities;
using TriNguyen.AtmSimulation.SharedKernel;

namespace TriNguyen.AtmSimulation.Core.Events
{
    public class AccountWithdrawalEvent : BaseDomainEvent
    {
        public Account CompletedItem { get; set; }

        public AccountWithdrawalEvent(Account completedItem)
        {
            CompletedItem = completedItem;
        }
    }
}

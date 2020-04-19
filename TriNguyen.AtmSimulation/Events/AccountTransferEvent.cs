using System;
using System.Collections.Generic;
using System.Text;
using TriNguyen.AtmSimulation.Core.Entities;
using TriNguyen.AtmSimulation.SharedKernel;

namespace TriNguyen.AtmSimulation.Core.Events
{
    public class AccountTransferEvent : BaseDomainEvent
    {
        public Account CompletedItem { get; set; }
        public int ToAccountId { get; set; }

        public AccountTransferEvent(Account completedItem, int toAccountId)
        {
            CompletedItem = completedItem;
            ToAccountId = toAccountId;
        }
    }
}

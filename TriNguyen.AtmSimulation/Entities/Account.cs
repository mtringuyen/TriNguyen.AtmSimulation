using System;
using System.Collections.Generic;
using System.Text;
using TriNguyen.AtmSimulation.Core.Events;
using TriNguyen.AtmSimulation.SharedKernel;

namespace TriNguyen.AtmSimulation.Core.Entities
{
    public class Account : BaseEntity
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; }
        public int UserId { get; set; }
        public decimal Balance { get; private set; } = 0;
        public string Type { get; set; }

        public void Deposit(decimal amount)
        {
            Balance += amount;
            Events.Add(new AccountDepositEvent(this));
        }

        public void Withdrawal(decimal amount)
        {
            if (Balance >= amount)
            {
                Balance = Balance - amount;
            }
            Events.Add(new AccountWithdrawalEvent(this));
        }

        public void Transfer(decimal amount, int toAccountId)
        {
            if (Balance >= amount)
            {
                Balance = Balance - amount;
            }
            Events.Add(new AccountTransferEvent(this, toAccountId));
        }
    }

    public enum AccountType
    {
        Checking = 0,
        Saving = 1
    }
}

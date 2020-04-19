using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TriNguyen.AtmSimulation.Core.Entities;
using TriNguyen.AtmSimulation.Core.Events;
using TriNguyen.AtmSimulation.SharedKernel.Interfaces;

namespace TriNguyen.AtmSimulation.Core.Handlers
{
    class TransferCompletedHandler : IHandle<AccountTransferEvent>
    {
        private readonly IRepository _repository;

        public TransferCompletedHandler(IRepository repository)
        {
            _repository = repository;
        }
        public Task Handle(AccountTransferEvent domainEvent)
        {
            //Guard.Against.Null(domainEvent, nameof(domainEvent));

            // deposit to new account
            var toAccount = _repository.GetById<Account>(domainEvent.ToAccountId);
            toAccount.Deposit(domainEvent.ToAccountId);
            _repository.Update(toAccount);
            return Task.CompletedTask;
        }
    }
}

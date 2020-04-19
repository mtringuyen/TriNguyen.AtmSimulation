using System;
using System.Collections.Generic;
using System.Text;
using TriNguyen.AtmSimulation.SharedKernel;

namespace TriNguyen.AtmSimulation.Core.Entities
{
    public class User : BaseEntity
    {
        public string UserName { get; set; } = string.Empty;
        public string PinNumber { get; set; }
        //public void MarkComplete()
        //{
        //    IsDone = true;
        //    //Events.Add(new AccountDepositEvent(this));
        //}
    }
}

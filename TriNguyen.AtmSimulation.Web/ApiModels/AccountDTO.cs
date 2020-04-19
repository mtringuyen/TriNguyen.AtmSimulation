using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TriNguyen.AtmSimulation.Core.Entities;

namespace TriNguyen.AtmSimulation.Web.ApiModels
{
    public class AccountDTO
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Balance { get; set; }
        public AccountType Type { get; set; }

        public static AccountDTO FromAccount(Account item)
        {
            Enum.TryParse(item.Type, out AccountType accountType);
            return new AccountDTO()
            {
                Id = item.Id,
                Title = item.Title,
                Description = item.Description,
                Balance = item.Balance,
                Type = accountType
            };
        }
    }
}

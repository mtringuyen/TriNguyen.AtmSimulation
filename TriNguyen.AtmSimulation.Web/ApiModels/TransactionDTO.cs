using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TriNguyen.AtmSimulation.Core.Entities;

namespace TriNguyen.AtmSimulation.Web.ApiModels
{
    public class TransactionDTO
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public int ToAccountid { get; set; }
        public IEnumerable<SelectListItem> Accounts { get; set; }
    }
}

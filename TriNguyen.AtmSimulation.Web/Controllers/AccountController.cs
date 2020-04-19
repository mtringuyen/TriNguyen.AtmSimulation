using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TriNguyen.AtmSimulation.Core;
using TriNguyen.AtmSimulation.Core.Entities;
using TriNguyen.AtmSimulation.SharedKernel.Interfaces;
using TriNguyen.AtmSimulation.Web.ApiModels;

namespace TriNguyen.AtmSimulation.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IRepository _repository;

        public AccountController(IRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            var items = _repository.List<Account>()
                            .Select(AccountDTO.FromAccount);
            return View(items);
        }

        public IActionResult Populate()
        {
            int recordsAdded = DatabasePopulator.PopulateDatabase(_repository);
            return Ok(recordsAdded);
        }
    }
}

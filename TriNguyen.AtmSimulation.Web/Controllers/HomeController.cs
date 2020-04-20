using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using TriNguyen.AtmSimulation.Core.Entities;
using TriNguyen.AtmSimulation.SharedKernel.Interfaces;
using TriNguyen.AtmSimulation.Web.ApiModels;
using TriNguyen.AtmSimulation.Web.Models;

namespace TriNguyen.AtmSimulation.Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRepository _repository;

        public HomeController(ILogger<HomeController> logger, IRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public IActionResult Index()
        {
            var userId = int.Parse(HttpContext.User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value);

            var items = _repository.List<Account>().Where(a => a.UserId == userId)
                            .Select(AccountDTO.FromAccount).ToList();
            return View(items);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddAccount()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Deposit(TransactionDTO model)
        {
            return View(model);
        }

        [HttpPost]
        public IActionResult AddDeposit(TransactionDTO model)
        {
            var account = _repository.List<Account>().First(a => a.Id == model.Id);
            account.Deposit(model.Amount);
            _repository.Update(account);

            return RedirectToAction("Index", "Home");            
        }

        [HttpGet]
        public IActionResult Withdrawal(TransactionDTO model)
        {
            return View(model);
        }

        [HttpPost]
        public IActionResult DoWithdrawal(TransactionDTO model)
        {
            var account = _repository.List<Account>().First(a => a.Id == model.Id);
            account.Withdrawal(model.Amount);
            _repository.Update(account);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Transfer(TransactionDTO model)
        {
            var userId = int.Parse(HttpContext.User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value);

            var accounts = _repository.List<Account>().Where(a => a.UserId == userId && a.Id != model.Id).Select(i => new SelectListItem { Value = i.Id.ToString(), Text = i.Title }).ToList();
            model.Accounts = accounts;
            return View(model);
        }

        [HttpPost]
        public IActionResult DoTransfer(TransactionDTO model)
        {
            var account = _repository.List<Account>().First(a => a.Id == model.Id);
            account.Transfer(model.Amount, model.ToAccountid);
            _repository.Update(account);

            return RedirectToAction("Index", "Home");
        }

        [HttpPost, AutoValidateAntiforgeryToken]
        public IActionResult AddAccount(AccountDTO item)
        {
            var userId = int.Parse(HttpContext.User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value);
            var account = new Account()
            {
                Title = item.Title,
                Description = item.Description,
                Type = item.Type.ToString("g"),
                UserId = userId
            };
            _repository.Add(account);

            return RedirectToAction("Index", "Home");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

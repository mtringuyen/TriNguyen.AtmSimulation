using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TriNguyen.AtmSimulation.Core.Entities;
using TriNguyen.AtmSimulation.SharedKernel.Interfaces;
using TriNguyen.AtmSimulation.Web.ApiModels;

namespace TriNguyen.AtmSimulation.Web.Api
{
    public class AccountsController : BaseApiController
    {
        private readonly IRepository _repository;

        public AccountsController(IRepository repository)
        {
            _repository = repository;
        }

        // GET: api/ToDoItems
        [HttpGet]
        public IActionResult List()
        {
            var items = _repository.List<Account>()
                            .Select(AccountDTO.FromAccount);
            return Ok(items);
        }

        // GET: api/ToDoItems
        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var item = AccountDTO.FromAccount(_repository.GetById<Account>(id));
            return Ok(item);
        }

        // POST: api/ToDoItems
        [HttpPost]
        public IActionResult Post([FromBody] AccountDTO item)
        {
            var todoItem = new Account()
            {
                Title = item.Title,
                Description = item.Description
            };
            _repository.Add(todoItem);
            return Ok(AccountDTO.FromAccount(todoItem));
        }

        [HttpPatch("{id:int}/complete")]
        public IActionResult Complete(int id)
        {
            var toDoItem = _repository.GetById<Account>(id);
            //toDoItem.MarkComplete();
            _repository.Update(toDoItem);

            return Ok(AccountDTO.FromAccount(toDoItem));
        }
    }
}

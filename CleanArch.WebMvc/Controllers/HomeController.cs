using CleanArch.WebMvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace CleanArch.WebMvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMediator _mediator;


        public HomeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public IActionResult Index()
        {
            var todos = _mediator.Send(new Core.Features.Todo.Queries.ListAll()).Result;
            return View(todos);
        }

        public async Task<IActionResult> Add(Core.Features.Todo.Commands.AddTodo command)
        {
            await _mediator.Send(command);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Complete(Core.Features.Todo.Commands.CompleteTodo command)
        {
            await _mediator.Send(command);
            return RedirectToAction("Index");
        }
    }
}

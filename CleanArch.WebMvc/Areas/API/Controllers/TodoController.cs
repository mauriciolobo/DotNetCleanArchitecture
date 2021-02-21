using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArch.Core.Features.Todo.Queries;
using MediatR;

namespace CleanArch.WebMvc.Areas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly IMediator _mediator;


        public TodoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("listAll")]
        public async Task<ActionResult<List<TodoDto>>> ListAll()
        {
            var todos = await _mediator.Send(new Core.Features.Todo.Queries.ListAll());
            return Ok(todos);
        }

        [HttpPost("create")]
        public async Task<ActionResult<int>> Add(Core.Features.Todo.Commands.AddTodo command)
        {
            var todoId = await _mediator.Send(command);
            return Ok(new { Id = todoId });
        }

        [HttpPost("complete")]
        public async Task<ActionResult> Complete(Core.Features.Todo.Commands.CompleteTodo command)
        {
            await _mediator.Send(command);
            return Ok();
        }
    }
}

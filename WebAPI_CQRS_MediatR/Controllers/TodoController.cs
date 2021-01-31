using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebAPI_CQRS_MediatR.Commands;
using WebAPI_CQRS_MediatR.Queries;

namespace WebAPI_CQRS_MediatR.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TodoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("/{id}")]
        public async Task<IActionResult> GetTodoById(int id)
        {
            var response = await _mediator.Send(new GetTodoById.Query(id));
            return response == null ? NotFound() : Ok(response);
        }

        [HttpPost("")]
        public async Task<IActionResult> AddTodo(AddTodo.Command command) => Ok(await _mediator.Send(command));
    }
}

using CQRS_Test_Project.Core.Application.Features.Commands.SubTask.UpdateSubTag;
using CQRS_Test_Project.Core.Application.Features.Commands.Tag.CreateTag;
using CQRS_Test_Project.Core.Application.Features.Commands.Task.CreateTask;
using CQRS_Test_Project.Core.Application.Features.Commands.Task.DeleteTask;
using CQRS_Test_Project.Core.Application.Features.Commands.Task.UpdateTask;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CQRS_Test_Project.Presentation.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TaskController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTask([FromBody] CreateTaskCommanRequest request)
        {

            var result = await _mediator.Send(request);

            return Ok(result);

        }

        [HttpPut]
        public async Task<IActionResult> UpdateTask([FromBody] UpdateTaskCommandRequest request)
        {
            var result = await _mediator.Send(request);

            return Ok(result);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(Guid id)
        {

            var command = new DeleteTaskCommandRequest()
            {
                Id = id
            };


            var response = await _mediator.Send(command);

            if (response.isSuccess)
            {
                return Ok(response.Data);
            }
            else
            {
                return NotFound(response.Errors);
            }
        }
    }
}

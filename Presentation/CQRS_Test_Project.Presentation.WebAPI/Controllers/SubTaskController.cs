using AutoMapper;
using CQRS_Test_Project.Core.Application.Features.Commands.SubTask.CreateSubTag;
using CQRS_Test_Project.Core.Application.Features.Commands.SubTask.DeleteSubTag;
using CQRS_Test_Project.Core.Application.Features.Commands.SubTask.UpdateSubTag;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CQRS_Test_Project.Presentation.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubTaskController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SubTaskController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateSubTask([FromBody] CreateSubTaskCommandRequest request)
        {

            var result = await _mediator.Send(request);

            return Ok(result);

        }

        [HttpPut]
        public async Task<IActionResult> UpdateSubTask([FromBody] UpdateSubTaskCommandRequest request)
        {
            var result = await _mediator.Send(request);

            return Ok(result);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubTask(Guid id)
        {

            var command = new DeleteSubTaskCommandRequest()
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

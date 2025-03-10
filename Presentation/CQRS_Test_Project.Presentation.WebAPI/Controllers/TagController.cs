using CQRS_Test_Project.Core.Application.Features.Commands.SubTask.CreateSubTag;
using CQRS_Test_Project.Core.Application.Features.Commands.SubTask.DeleteSubTag;
using CQRS_Test_Project.Core.Application.Features.Commands.SubTask.UpdateSubTag;
using CQRS_Test_Project.Core.Application.Features.Commands.Tag.CreateTag;
using CQRS_Test_Project.Core.Application.Features.Commands.Tag.UpdateTag;
using CQRS_Test_Project.Core.Application.Features.Commands.Task.DeleteTask;
using CQRS_Test_Project.Core.Application.Features.Queries.Tag.GetAllTag;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CQRS_Test_Project.Presentation.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TagController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTag([FromBody] CreateTagCommandRequest request)
        {

            var result = await _mediator.Send(request);

            return Ok(result);

        }

        [HttpPut]
        public async Task<IActionResult> UpdateTag([FromBody] UpdateTagCommandRequest request)
        {
            var result = await _mediator.Send(request);

            return Ok(result);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTag(Guid id)
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
        [HttpGet("GetAllTag")]
        public async Task<IActionResult> GetAllProject()
        {
          
            var result = await _mediator.Send(new GetAllTagQueryRequest());
            if (result.isSuccess)
                return Ok(result);
            return NotFound(result);
        }
    }
}

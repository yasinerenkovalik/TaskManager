using AutoMapper;
using CQRS_Test_Project.Core.Application.Features.Commands.SubTask.CreateSubTag;
using CQRS_Test_Project.Core.Application.Features.Commands.SubTask.DeleteSubTag;
using CQRS_Test_Project.Core.Application.Features.Commands.SubTask.UpdateSubTag;
using CQRS_Test_Project.Core.Application.Features.Queries.SubTask.GetAllSubTask;
using CQRS_Test_Project.Core.Application.Features.Queries.SubTask.GetByIdSubTask;
using CQRS_Test_Project.Core.Application.Features.Queries.SubTask.GetByTaskSubTask;
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
        [HttpGet("GetAllSubTasks")]
        public async Task<IActionResult> GetAllProject()
        {
          
            var result = await _mediator.Send(new GetAllSubTaskQueryRequest());
            if (result.isSuccess)
                return Ok(result);
            return NotFound(result);
        }
        [HttpGet("GetByIdSubTasks")]
        public async Task<IActionResult> GetByIdSubTasks(Guid id)
        {
          
            var result = await _mediator.Send(new GetByIdSubTaskRequest
            {
                Id = id
            });
            if (result.isSuccess)
                return Ok(result);
            return NotFound(result);
        }
        [HttpGet("GetByTaskSubTasks")]
        public async Task<IActionResult> GetByTaskSubTasks(Guid id)
        {
          
            var result = await _mediator.Send(new GetByTaskSubTaskRequest()
            { 
                TaskId= id
            });
            if (result.isSuccess)
                return Ok(result);
            return NotFound(result);
        }
    }
}

using CQRS_Test_Project.Core.Application.Features.Commands.WorkFlow.CreateWorkFlow;
using CQRS_Test_Project.Core.Application.Features.Commands.WorkFlow.DeleteWorkFlow;
using CQRS_Test_Project.Core.Application.Features.Commands.WorkFlow.UpdateWorkFlow;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CQRS_Test_Project.Presentation.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkFlowController : ControllerBase
    {
        private readonly IMediator _mediator;

        public WorkFlowController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateWorkFlow([FromBody] CreateWorkFlowCommandRequest request)
        {

            var result = await _mediator.Send(request);

            return Ok(result);

        }

        [HttpPut]
        public async Task<IActionResult> UpdateWorkFlow([FromBody] UpdateWorkFlowCommandRequest request)
        {
            var result = await _mediator.Send(request);

            return Ok(result);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWorkFlow(Guid id)
        {

            var command = new DeleteWorkFlowCommandRequest()
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

using CQRS_Test_Project.Core.Application.Features.Commands.WorkFlow.CreateWorkFlow;
using CQRS_Test_Project.Core.Application.Features.Commands.WorkFlow.DeleteWorkFlow;
using CQRS_Test_Project.Core.Application.Features.Commands.WorkFlow.UpdateWorkFlow;
using CQRS_Test_Project.Core.Application.Features.Queries.WorkFlow.GetAllWorkFlow;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CQRS_Test_Project.Presentation.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkFlowController(IMediator mediator) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateWorkFlow([FromBody] CreateWorkFlowCommandRequest request)
        {

            var result = await mediator.Send(request);

            return Ok(result);

        }

        [HttpPut]
        public async Task<IActionResult> UpdateWorkFlow([FromBody] UpdateWorkFlowCommandRequest request)
        {
            var result = await mediator.Send(request);

            return Ok(result);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWorkFlow(Guid id)
        {

            var command = new DeleteWorkFlowCommandRequest()
            {
                Id = id
            };


            var response = await mediator.Send(command);

            if (response.isSuccess)
            {
                return Ok(response.Data);
            }
            else
            {
                return NotFound(response.Errors);
            }
        }
        [HttpGet("GetAllWorkFlows")]
       
        public async Task<IActionResult> GetAllUsers()
        {
          
            var result = await mediator.Send(new GetAllWorkFlowQueryRequest());
            if (result.isSuccess)
                return Ok(result);
            return NotFound(result);
        }
    
    }
}

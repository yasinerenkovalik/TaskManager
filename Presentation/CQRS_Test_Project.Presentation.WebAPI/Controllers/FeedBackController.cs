using CQRS_Test_Project.Core.Application.Features.Commands.FeedBack.CreateFeedBack;
using CQRS_Test_Project.Core.Application.Features.Commands.FeedBack.DeleteFeedBack;
using CQRS_Test_Project.Core.Application.Features.Commands.FeedBack.UpdateFeedBack;
using CQRS_Test_Project.Core.Application.Features.Queries.FeedBack.GetAllFeedBack;
using CQRS_Test_Project.Core.Application.Features.Queries.FeedBack.GetByIdFeedBack;
using CQRS_Test_Project.Core.Application.Features.Queries.User.GetAllUser;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CQRS_Test_Project.Presentation.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedBackController : ControllerBase
    {
        private  readonly IMediator _mediator;

        public FeedBackController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> CreateFeedBack([FromBody] CreateFeedBackCommandRequest request)
        {
          
            var result = await _mediator.Send(request);

            return Ok(result);

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
           
            var command = new DeleteFeedBackCommandRequest()
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
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateFeedBackCommandRequest request)
        {
            var result = await _mediator.Send(request);

            return Ok(result);

        }
        [HttpGet("GetAllFeedBacks")]
        public async Task<IActionResult> GetAllFeedBacks()
        {
          
            var result = await _mediator.Send(new GetAllFeedBackQueryRequest());
            if (result.isSuccess)
                return Ok(result);
            return NotFound(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetFeedBackById([FromQuery] GetByIdFeedBackQueyRequest request)
        {
          
            var result = await _mediator.Send(request);

            return Ok(result);

        }
    }
}

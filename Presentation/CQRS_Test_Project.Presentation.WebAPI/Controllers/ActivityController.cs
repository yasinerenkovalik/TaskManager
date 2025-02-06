using AutoMapper;
using CQRS_Test_Project.Core.Application.Features.Commands.ActivityLog.CreateActivityLog;
using CQRS_Test_Project.Core.Application.Features.Commands.ActivityLog.DeleteActivityLog;
using CQRS_Test_Project.Core.Application.Features.Commands.ActivityLog.UpdateActivityLog;
using CQRS_Test_Project.Core.Application.Features.Queries.ActivityLog.GetAllActivityLog;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CQRS_Test_Project.Presentation.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ActivityController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAllUsers")]
        public async Task<IActionResult> GetAllActivities()
        {
            var result = await _mediator.Send(new GetAllActivityLogQueryRequest());
            if (result.isSuccess)
                return Ok(result);
            return NotFound(result);
        }
        [HttpPost]
        public async Task<IActionResult> AddActivities([FromForm] CreateActivityLogCommandRequest request)
        {
            var result = await _mediator.Send(request);
            if (result!=null)
                return Ok(result);
            return NotFound(result);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateActivities([FromForm] UpdateActivityLogCommandRequest request)
        {
            var result = await _mediator.Send(request);
            if (result!=null)
                return Ok(result);
            return NotFound(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActivities([FromForm] DeleteActivityLogCommandRequest request)
        {
            var result = await _mediator.Send(request);
            if (result!=null)
                return Ok(result);
            return NotFound(result);
        }
    }
}

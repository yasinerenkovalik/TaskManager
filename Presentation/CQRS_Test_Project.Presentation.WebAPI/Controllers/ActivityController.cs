using AutoMapper;
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

        [HttpGet]
        public async Task<IActionResult> GetAllActivities()
        {
            var result = await _mediator.Send(new GetAllActivityLogQueryRequest());
            if (result.isSuccess)
                return Ok(result);
            return NotFound(result);
        }
    }
}

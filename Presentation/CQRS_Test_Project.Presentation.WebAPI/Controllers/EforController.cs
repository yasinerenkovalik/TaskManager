using CQRS_Test_Project.Core.Application.Features.Commands.Efor.CreateEfor;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CQRS_Test_Project.Presentation.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EforController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EforController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> AddActivities([FromBody] CreateEforRequest request)
        {
            var result = await _mediator.Send(request);
            if (result!=null)
                return Ok(result);
            return NotFound(result);
        }
    }
}

using CQRS_Test_Project.Core.Application.Features.Commands.User.CreateUser;
using CQRS_Test_Project.Core.Application.Features.Queries.User.GetByIdUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRS_Test_Project.Presentation.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UserController : ControllerBase
    {
        IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserCommandRequest request)
        {
            var result = await _mediator.Send(request);

            return Ok(result);

        }

        [HttpGet]
        public async Task<IActionResult> GetUserById([FromQuery] GetByIdUserQueryRequest request)
        {
            var result = await _mediator.Send(request);

            return Ok(result);

        }


    }
}

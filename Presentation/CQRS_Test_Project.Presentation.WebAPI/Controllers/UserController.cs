using CQRS_Test_Project.Core.Application.Features.Commands.User.CreateUser;
using CQRS_Test_Project.Core.Application.Features.Commands.User.DeleteUser;
using CQRS_Test_Project.Core.Application.Features.Commands.User.UpdateUser;
using CQRS_Test_Project.Core.Application.Features.Queries.User.GetAllUser;
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
            if (ModelState.IsValid)
            {

            }
            var result = await _mediator.Send(request);

            return Ok(result);

        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateUserCommandRequest request)
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
        [HttpGet("GetAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
          
            var result = await _mediator.Send(new GetAllUserQueryRequest());
            if (result.isSuccess)
                return Ok(result);
            return NotFound(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
           
            var command = new DeleteUserCommanRequest
            {
                UserId = id
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

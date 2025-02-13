using CQRS_Test_Project.Core.Application.Features.Commands.Team.CreateTeam;
using CQRS_Test_Project.Core.Application.Features.Commands.Team.DeleteTeam;
using CQRS_Test_Project.Core.Application.Features.Commands.Team.UpdateTeam;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CQRS_Test_Project.Presentation.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TeamController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTeam([FromBody] CreateTeamCommandRequest request)
        {

            var result = await _mediator.Send(request);

            return Ok(result);

        }

        [HttpPut]
        public async Task<IActionResult> UpdateTeam([FromBody] UpdateTeamCommandRequest request)
        {
            var result = await _mediator.Send(request);

            return Ok(result);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeam(Guid id)
        {

            var command = new DeleteTeamCommandRequest()
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

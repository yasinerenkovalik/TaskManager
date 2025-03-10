using CQRS_Test_Project.Core.Application.Features.Commands.TeamMember.CreateTeamMember;
using CQRS_Test_Project.Core.Application.Features.Commands.TeamMember.DeleteTeamMember;
using CQRS_Test_Project.Core.Application.Features.Commands.TeamMember.UpdateTeamMember;
using CQRS_Test_Project.Core.Application.Features.Queries.TeamMember.GetAllTeamMember;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CQRS_Test_Project.Presentation.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamMemberController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TeamMemberController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTeam([FromBody] CreateTeamMemberCommandRequest request)
        {

            var result = await _mediator.Send(request);

            return Ok(result);

        }

        [HttpPut]
        public async Task<IActionResult> UpdateTeam([FromBody] UpdateTeamMemberCommandRequest request)
        {
            var result = await _mediator.Send(request);

            return Ok(result);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeam(Guid id)
        {

            var command = new DeleteTeamMemberCommandRequest()
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
        [HttpGet("GetAllTeamMember")]
        public async Task<IActionResult> GetAllProject()
        {
          
            var result = await _mediator.Send(new GetAllTeamMemberQueryRequest());
            if (result.isSuccess)
                return Ok(result);
            return NotFound(result);
        }
    }
}

using CQRS_Test_Project.Core.Application.Features.Commands.Project.CreateProject;
using CQRS_Test_Project.Core.Application.Features.Commands.Project.DeleteProject;
using CQRS_Test_Project.Core.Application.Features.Commands.Project.UpdateProject;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CQRS_Test_Project.Presentation.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private  readonly IMediator _mediator;

        public ProjectController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> CreateProject([FromBody] CreateProjectCommandRequest request)
        {
          
            var result = await _mediator.Send(request);

            return Ok(result);

        }
        [HttpPut]
        public async Task<IActionResult> UpdateProject([FromBody] UpdateProjectCommandRequest request)
        {
            var result = await _mediator.Send(request);

            return Ok(result);

        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProject(Guid id)
        {
           
            var command = new DeleteProjectCommandRequest()
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

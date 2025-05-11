using CQRS_Test_Project.Core.Application.Features.Commands.Project.CreateProject;
using CQRS_Test_Project.Core.Application.Features.Commands.Project.DeleteProject;
using CQRS_Test_Project.Core.Application.Features.Commands.Project.UpdateProject;
using CQRS_Test_Project.Core.Application.Features.Queries.Project.GetAllProject;
using CQRS_Test_Project.Core.Application.Features.Queries.Project.GetByIdProject;
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
        [HttpGet("GetAllProject")]
        public async Task<IActionResult> GetAllProject()
        {
          
            var result = await _mediator.Send(new GetAllProjectQueryRequest());
            if (result.isSuccess)
                return Ok(result);
            return NotFound(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdProject(Guid id)
        {
            var project = new GetByIdProjectQueryRequest()
            {
                Id = id
            };

          
            var result = await _mediator.Send(project);
            if (result.isSuccess)
                return Ok(result);
            return NotFound(result);
        }
    }
}

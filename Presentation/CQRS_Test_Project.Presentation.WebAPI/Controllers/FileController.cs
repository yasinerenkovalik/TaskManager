using CQRS_Test_Project.Core.Application.Features.Commands.FeedBack.CreateFeedBack;
using CQRS_Test_Project.Core.Application.Features.Commands.FeedBack.UpdateFeedBack;
using CQRS_Test_Project.Core.Application.Features.Commands.File.CreateFile;
using CQRS_Test_Project.Core.Application.Features.Commands.File.DeleteFile;
using CQRS_Test_Project.Core.Application.Features.Commands.File.UpdateFile;
using CQRS_Test_Project.Core.Application.Features.Queries.File.GetAllFile;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CQRS_Test_Project.Presentation.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FileController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> CreateFile([FromBody] CreateFileCommandRequest request)
        {
          
            var result = await _mediator.Send(request);

            return Ok(result);

        }
   
        [HttpPut]
        public async Task<IActionResult> UpdateFile([FromBody] UpdateFileCommandRequest request)
        {
            var result = await _mediator.Send(request);

            return Ok(result);

        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFile(Guid id)
        {
           
            var command = new DeleteFileCommandRequest()
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
        [HttpGet("GetAllFile")]
        public async Task<IActionResult> GetAllProject()
        {
          
            var result = await _mediator.Send(new GetAllFileQueryRequest());
            if (result.isSuccess)
                return Ok(result);
            return NotFound(result);
        }
    }
}

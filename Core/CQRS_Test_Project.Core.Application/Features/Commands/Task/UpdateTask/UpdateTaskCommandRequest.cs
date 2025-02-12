using CQRS_Test_Project.Core.Application.Wrappers;
using MediatR;

namespace CQRS_Test_Project.Core.Application.Features.Commands.Task.UpdateTask;

public class UpdateTaskCommandRequest:IRequest<GeneralResponse<UpdateTaskCommandResponse>>
{
    public Guid Id { get; set; } 
    public string Title { get; set; }
    public string Description { get; set; }
    public string Priority { get; set; }
    public string Status { get; set; }
    public Guid UserId { get; set; }
}
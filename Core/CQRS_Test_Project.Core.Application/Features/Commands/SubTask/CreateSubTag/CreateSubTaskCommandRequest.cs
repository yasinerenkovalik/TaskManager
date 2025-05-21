using CQRS_Test_Project.Core.Application.Wrappers;
using MediatR;

namespace CQRS_Test_Project.Core.Application.Features.Commands.SubTask.CreateSubTag;

public class CreateSubTaskCommandRequest:IRequest<GeneralResponse<CreateSubTaskCommandResponse>>
{
    public Guid TaskId { get; set; }
    public string Title { get; set; }
    public string Status { get; set; }
    public Guid UserId { get; set; }
    public string Description { get; set; }
}
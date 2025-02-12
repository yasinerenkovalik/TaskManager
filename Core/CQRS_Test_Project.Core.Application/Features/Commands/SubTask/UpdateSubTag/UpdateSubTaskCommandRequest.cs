using CQRS_Test_Project.Core.Application.Wrappers;
using MediatR;

namespace CQRS_Test_Project.Core.Application.Features.Commands.SubTask.UpdateSubTag;

public class UpdateSubTaskCommandRequest:IRequest<GeneralResponse<UpdateSubTaskCommandResponse>>
{
    public Guid Id { get; set; }
    public Guid TaskId { get; set; }
    public string Title { get; set; }
    public string Status { get; set; }
}
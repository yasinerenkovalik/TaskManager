using MediatR;

namespace CQRS_Test_Project.Core.Application.Features.Commands.ActivityLog.CreateActivityLog;

public class CreateActivityLogCommandRequest:IRequest<CreateActivityLogCommandResponse>
{
    public Guid TaskId { get; set; }  
    public Guid UserId { get; set; }
    public string Action { get; set; }	
}
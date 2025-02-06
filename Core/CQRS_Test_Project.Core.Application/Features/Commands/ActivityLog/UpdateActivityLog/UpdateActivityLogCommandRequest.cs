using CQRS_Test_Project.Core.Application.Wrappers;
using MediatR;

namespace CQRS_Test_Project.Core.Application.Features.Commands.ActivityLog.UpdateActivityLog;

public class UpdateActivityLogCommandRequest:IRequest<GeneralResponse<UpdateActivityLogCommandResponse>>
{
    public Guid BaseID { get; set; }
    public Guid TaskId { get; set; }  
    public Guid UserId { get; set; }
    public string Action { get; set; }	
}
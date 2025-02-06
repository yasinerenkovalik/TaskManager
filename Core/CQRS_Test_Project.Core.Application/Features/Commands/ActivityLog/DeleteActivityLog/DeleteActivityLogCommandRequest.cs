using CQRS_Test_Project.Core.Application.Wrappers;
using MediatR;

namespace CQRS_Test_Project.Core.Application.Features.Commands.ActivityLog.DeleteActivityLog;

public class DeleteActivityLogCommandRequest:IRequest<GeneralResponse<DeleteActivityLogCommandResponse>>
{
    public Guid Id { get; set; }
}
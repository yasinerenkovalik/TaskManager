using CQRS_Test_Project.Core.Application.Wrappers;
using MediatR;

namespace CQRS_Test_Project.Core.Application.Features.Commands.WorkFlow.UpdateWorkFlow;

public class UpdateWorkFlowCommandRequest:IRequest<GeneralResponse<UpdateWorkFlowCommandResponse>>
{
    public Guid Id { get; set; }
    public Guid TaskId { get; set; }
    public string Stage { get; set; }
}
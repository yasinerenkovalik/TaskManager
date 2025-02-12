using CQRS_Test_Project.Core.Application.Wrappers;
using MediatR;

namespace CQRS_Test_Project.Core.Application.Features.Commands.WorkFlow.CreateWorkFlow;

public class CreateWorkFlowCommandRequest:IRequest<GeneralResponse<CreateWorkFlowCommandResponse>>
{
    public Guid TaskId { get; set; }
    public string Stage { get; set; }
}
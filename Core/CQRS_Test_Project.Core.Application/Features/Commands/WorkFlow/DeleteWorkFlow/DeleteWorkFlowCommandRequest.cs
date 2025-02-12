using CQRS_Test_Project.Core.Application.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CQRS_Test_Project.Core.Application.Features.Commands.WorkFlow.DeleteWorkFlow;

public class DeleteWorkFlowCommandRequest:IRequest<GeneralResponse<DeleteWorkFlowCommandResponse>>
{
    public Guid Id { get; set; }
}
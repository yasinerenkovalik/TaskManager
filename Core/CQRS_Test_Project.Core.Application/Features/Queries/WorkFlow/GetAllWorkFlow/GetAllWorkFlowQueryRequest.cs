using CQRS_Test_Project.Core.Application.Wrappers;
using MediatR;

namespace CQRS_Test_Project.Core.Application.Features.Queries.WorkFlow.GetAllWorkFlow;

public class GetAllWorkFlowQueryRequest:IRequest<GeneralResponse<List<GetAllWorkFlowQueryResponse>>>
{
    
}
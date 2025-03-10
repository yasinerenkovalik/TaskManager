using AutoMapper;
using CQRS_Test_Project.Core.Application.Interface.Repository;
using CQRS_Test_Project.Core.Application.Wrappers;
using MediatR;

namespace CQRS_Test_Project.Core.Application.Features.Queries.WorkFlow.GetAllWorkFlow;

public class GetAllWorkFlowQueryRequestHandler(IMapper mapper, IWorkflowRepository workflowRepository)
    : IRequestHandler<GetAllWorkFlowQueryRequest, GeneralResponse<List<GetAllWorkFlowQueryResponse>>>
{
    public async Task<GeneralResponse<List<GetAllWorkFlowQueryResponse>>> Handle(GetAllWorkFlowQueryRequest request, CancellationToken cancellationToken)
    {
        var workFlowEntities = await workflowRepository.GetAllAysnc();

        if (workFlowEntities == null || !workFlowEntities.Any())
        {
            return new GeneralResponse<List<GetAllWorkFlowQueryResponse>>
            {
                Data = null,
                Errors = new List<string> { "work Flow bulunamadı." },
                isSuccess = false
            };
        }

           
        var getWorkFlowQueryResponse = mapper.Map<List<GetAllWorkFlowQueryResponse>>(workFlowEntities);

        return new GeneralResponse<List<GetAllWorkFlowQueryResponse>>
        {
            Data = getWorkFlowQueryResponse,
            Errors = null,
            isSuccess = true
        };
    }
}
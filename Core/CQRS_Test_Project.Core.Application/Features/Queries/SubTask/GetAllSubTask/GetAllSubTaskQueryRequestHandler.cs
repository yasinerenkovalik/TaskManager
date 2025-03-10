using AutoMapper;
using CQRS_Test_Project.Core.Application.Interface.Repository;
using CQRS_Test_Project.Core.Application.Wrappers;
using MediatR;

namespace CQRS_Test_Project.Core.Application.Features.Queries.SubTask.GetAllSubTask;

public class GetAllSubTaskQueryRequestHandler(ISubTaskRepository subTaskRepository, IMapper mapper):IRequestHandler<GetAllSubTaskQueryRequest, GeneralResponse<List<GetAllSubTaskQueryResponse>>>
{
    private readonly ISubTaskRepository _subTaskRepository = subTaskRepository;
    private readonly IMapper _mapper = mapper;
    public async Task<GeneralResponse<List<GetAllSubTaskQueryResponse>>> Handle(GetAllSubTaskQueryRequest request, CancellationToken cancellationToken)
    {
        var subTasks = await _subTaskRepository.GetAllAysnc();

        if (subTasks == null)
        {
            return new GeneralResponse<List<GetAllSubTaskQueryResponse>>
            {
                Data = null,
                Errors = new List<string> { "Project bulunamadı." },
                isSuccess = false
            };
        }
        
        var getAllProjectQueryResponse = _mapper.Map<List<GetAllSubTaskQueryResponse>>(subTasks);

        return new GeneralResponse<List<GetAllSubTaskQueryResponse>>
        {
            Data = getAllProjectQueryResponse,
            Errors = null,
            isSuccess = true
        };
    }
}
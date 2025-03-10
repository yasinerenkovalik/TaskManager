using AutoMapper;
using CQRS_Test_Project.Core.Application.Interface.Repository;
using CQRS_Test_Project.Core.Application.Wrappers;
using MediatR;

namespace CQRS_Test_Project.Core.Application.Features.Queries.Task.GetAllTask;

public class GetAllTaskQueryRequestHandler(ITaskRepository taskRepository, IMapper mapper):IRequestHandler<GetAllTaskQueryRequest, GeneralResponse<List<GetAllTaskQueryResponse>>>
{
    private readonly ITaskRepository _taskRepository = taskRepository;
    private readonly IMapper _mapper = mapper;
    public async Task<GeneralResponse<List<GetAllTaskQueryResponse>>> Handle(GetAllTaskQueryRequest request, CancellationToken cancellationToken)
    {
        var taskEntity = await _taskRepository.GetAllAysnc();

        if (taskEntity == null)
        {
            return new GeneralResponse<List<GetAllTaskQueryResponse>>
            {
                Data = null,
                Errors = new List<string> { "Project bulunamadı." },
                isSuccess = false
            };
        }
        
        var getAllProjectQueryResponse = _mapper.Map<List<GetAllTaskQueryResponse>>(taskEntity);

        return new GeneralResponse<List<GetAllTaskQueryResponse>>
        {
            Data = getAllProjectQueryResponse,
            Errors = null,
            isSuccess = true
        };
    }
}
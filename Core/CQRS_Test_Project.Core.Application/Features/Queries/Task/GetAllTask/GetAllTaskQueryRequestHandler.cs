using AutoMapper;
using CQRS_Test_Project.Core.Application.Interface.Repository;
using CQRS_Test_Project.Core.Application.Wrappers;
using MediatR;

namespace CQRS_Test_Project.Core.Application.Features.Queries.Task.GetAllTask;

public class GetAllTaskQueryRequestHandler(ITaskRepository taskRepository, IMapper mapper):IRequestHandler<GetAllTaskQueryRequest, GeneralResponse<List<GetAllTaskQueryResponse>>>
{
    public async Task<GeneralResponse<List<GetAllTaskQueryResponse>>> Handle(GetAllTaskQueryRequest request, CancellationToken cancellationToken)
    {
        var taskEntity = await taskRepository.GetAllAysnc();

        if (taskEntity == null)
        {
            return new GeneralResponse<List<GetAllTaskQueryResponse>>
            {
                Data = null,
                Errors = new List<string> { "Project bulunamadı." },
                isSuccess = false
            };
        }
        
        var getAllProjectQueryResponse = mapper.Map<List<GetAllTaskQueryResponse>>(taskEntity);

        return new GeneralResponse<List<GetAllTaskQueryResponse>>
        {
            Data = getAllProjectQueryResponse,
            Errors = null,
            isSuccess = true
        };
    }
}
using AutoMapper;
using CQRS_Test_Project.Core.Application.Features.Queries.Task.GetAllTask;
using CQRS_Test_Project.Core.Application.Interface.Repository;
using CQRS_Test_Project.Core.Application.Wrappers;
using MediatR;

namespace CQRS_Test_Project.Core.Application.Features.Queries.Task.GetByProjectTask;

public class GetByProjectTaskRequestHandler(ITaskRepository taskRepository, IMapper mapper):IRequestHandler<GetByProjectTaskRequest, GeneralResponse<List<GetByProjectTaskResponse>>>
{
    public async Task<GeneralResponse<List<GetByProjectTaskResponse>>> Handle(GetByProjectTaskRequest request, CancellationToken cancellationToken)
    {
        var taskEntity = await taskRepository.GetByProject(request.ProjectId);

        if (taskEntity == null)
        {
            return new GeneralResponse<List<GetByProjectTaskResponse>>
            {
                Data = null,
                Errors = new List<string> { "Project bulunamadı." },
                isSuccess = false
            };
        }
        var getAllProjectQueryResponse = mapper.Map<List<GetByProjectTaskResponse>>(taskEntity);

        return new GeneralResponse<List<GetByProjectTaskResponse>>
        {
            Data = getAllProjectQueryResponse,
            Errors = null,
            isSuccess = true
        };
    }
}
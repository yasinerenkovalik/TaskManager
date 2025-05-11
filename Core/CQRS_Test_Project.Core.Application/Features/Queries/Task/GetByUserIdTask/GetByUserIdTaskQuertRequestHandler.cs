using AutoMapper;
using CQRS_Test_Project.Core.Application.Interface.Repository;
using CQRS_Test_Project.Core.Application.Wrappers;
using MediatR;

namespace CQRS_Test_Project.Core.Application.Features.Queries.Task.GetByUserIdTask;

public class GetByUserIdTaskQuertRequestHandler(
    ITaskRepository taskRepository,
    IMapper mapper
) : IRequestHandler<GetByUserIdTaskQuertRequest, GeneralResponse<List<GetByUserIdTaskQuertResponse>>>
{
    public async Task<GeneralResponse<List<GetByUserIdTaskQuertResponse>>> Handle(GetByUserIdTaskQuertRequest request, CancellationToken cancellationToken)
    {
        var taskList = await taskRepository.GetByUserTask(request.UserId);

        if (taskList == null || !taskList.Any())
        {
            return new GeneralResponse<List<GetByUserIdTaskQuertResponse>>
            {
                Data = null,
                Errors = new List<string> { "Task bulunamadı." },
                isSuccess = false
            };
        }

        var result = mapper.Map<List<GetByUserIdTaskQuertResponse>>(taskList);

        return new GeneralResponse<List<GetByUserIdTaskQuertResponse>>
        {
            Data = result,
            isSuccess = true
        };
    }
}

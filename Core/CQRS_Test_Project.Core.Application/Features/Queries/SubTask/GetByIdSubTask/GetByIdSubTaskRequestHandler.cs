using AutoMapper;
using CQRS_Test_Project.Core.Application.Interface.Repository;
using CQRS_Test_Project.Core.Application.Wrappers;
using MediatR;

namespace CQRS_Test_Project.Core.Application.Features.Queries.SubTask.GetByIdSubTask;

public class GetByIdSubTaskRequestHandler(ISubTaskRepository subTaskRepository, IMapper mapper)
    : IRequestHandler<GetByIdSubTaskRequest, GeneralResponse<GetByIdSubTaskResponse>>
{
    public async Task<GeneralResponse<GetByIdSubTaskResponse>> Handle(GetByIdSubTaskRequest request, CancellationToken cancellationToken)
    {
        var subTasks = await subTaskRepository.GetByIdAsyncUser(request.Id);

        if (subTasks == null)
        {
            return new GeneralResponse<GetByIdSubTaskResponse>
            {
                Data = null,
                Errors = new List<string> { "Sub task  bulunamadı." },
                isSuccess = false
            };
        }
        
        var getAllProjectQueryResponse = mapper.Map<GetByIdSubTaskResponse>(subTasks);

        return new GeneralResponse<GetByIdSubTaskResponse>
        {
            Data = getAllProjectQueryResponse,
            Errors = null,
            isSuccess = true
        };
    }
}
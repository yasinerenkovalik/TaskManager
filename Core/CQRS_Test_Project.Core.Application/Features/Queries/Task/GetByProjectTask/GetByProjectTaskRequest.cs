using CQRS_Test_Project.Core.Application.Wrappers;
using MediatR;

namespace CQRS_Test_Project.Core.Application.Features.Queries.Task.GetByProjectTask;

public class GetByProjectTaskRequest:IRequest<GeneralResponse<List<GetByProjectTaskResponse>>>
{
    public Guid ProjectId { get; set; }
}
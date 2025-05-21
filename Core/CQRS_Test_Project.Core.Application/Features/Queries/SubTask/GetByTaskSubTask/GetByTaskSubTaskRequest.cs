using CQRS_Test_Project.Core.Application.Wrappers;
using CQRS_Test_Project.Core.Domain.Entities.Base;
using MediatR;

namespace CQRS_Test_Project.Core.Application.Features.Queries.SubTask.GetByTaskSubTask;

public class GetByTaskSubTaskRequest:IRequest<GeneralResponse<List<GetByTaskSubTaskResponse>>>
{
    public Guid TaskId { get; set; }
}
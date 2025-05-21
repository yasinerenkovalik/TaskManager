using CQRS_Test_Project.Core.Application.Wrappers;
using MediatR;

namespace CQRS_Test_Project.Core.Application.Features.Queries.SubTask.GetByIdSubTask;

public class GetByIdSubTaskRequest:IRequest<GeneralResponse<GetByIdSubTaskResponse>>
{
    public Guid Id { get; set; }
}
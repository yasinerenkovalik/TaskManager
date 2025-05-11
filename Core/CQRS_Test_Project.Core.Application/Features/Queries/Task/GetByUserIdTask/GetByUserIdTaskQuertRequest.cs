using CQRS_Test_Project.Core.Application.Wrappers;
using MediatR;

namespace CQRS_Test_Project.Core.Application.Features.Queries.Task.GetByUserIdTask;

public class GetByUserIdTaskQuertRequest:IRequest<GeneralResponse<List<GetByUserIdTaskQuertResponse>>>
{
    public Guid UserId { get; set; }
}
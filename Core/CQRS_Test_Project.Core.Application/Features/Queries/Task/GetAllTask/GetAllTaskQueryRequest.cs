using CQRS_Test_Project.Core.Application.Wrappers;
using MediatR;

namespace CQRS_Test_Project.Core.Application.Features.Queries.Task.GetAllTask;

public class GetAllTaskQueryRequest:IRequest<GeneralResponse<List<GetAllTaskQueryResponse>>>
{
    
}
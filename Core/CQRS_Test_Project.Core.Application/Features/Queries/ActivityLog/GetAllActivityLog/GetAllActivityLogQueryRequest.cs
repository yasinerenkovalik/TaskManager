using CQRS_Test_Project.Core.Application.Wrappers;
using MediatR;

namespace CQRS_Test_Project.Core.Application.Features.Queries.ActivityLog.GetAllActivityLog;

public class GetAllActivityLogQueryRequest:IRequest<GeneralResponse<List<GetAllActivityLogQueryResponse>>>
{
    
}
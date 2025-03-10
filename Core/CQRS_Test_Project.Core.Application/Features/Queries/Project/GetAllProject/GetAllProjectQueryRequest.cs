using CQRS_Test_Project.Core.Application.Features.Queries.FeedBack.GetByIdFeedBack;
using CQRS_Test_Project.Core.Application.Wrappers;
using MediatR;

namespace CQRS_Test_Project.Core.Application.Features.Queries.Project.GetAllProject;

public class GetAllProjectQueryRequest:IRequest<GeneralResponse<List<GetAllProjectQueryResponse>>>
{
    
}
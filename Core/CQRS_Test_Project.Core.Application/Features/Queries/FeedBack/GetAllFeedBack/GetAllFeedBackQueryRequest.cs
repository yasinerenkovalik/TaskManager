using CQRS_Test_Project.Core.Application.Wrappers;
using MediatR;

namespace CQRS_Test_Project.Core.Application.Features.Queries.FeedBack.GetAllFeedBack;

public  class GetAllFeedBackQueryRequest:IRequest<GeneralResponse<List<GetAllFeedBackQueryResponse>>>
{
    
}
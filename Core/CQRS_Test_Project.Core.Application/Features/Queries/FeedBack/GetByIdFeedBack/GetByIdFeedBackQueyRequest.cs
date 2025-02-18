using CQRS_Test_Project.Core.Application.Wrappers;
using MediatR;

namespace CQRS_Test_Project.Core.Application.Features.Queries.FeedBack.GetByIdFeedBack;

public class GetByIdFeedBackQueyRequest:IRequest<GeneralResponse<GetByIdFeedBackQueyResponse>>
{
    public Guid Id { get; set; }
}
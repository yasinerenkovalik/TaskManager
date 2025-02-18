namespace CQRS_Test_Project.Core.Application.Features.Queries.FeedBack.GetAllFeedBack;

public class GetAllFeedBackQueryResponse(string message)
{
    public Guid UserId { get; set; }
    public string Message { get; set; } = message;
}
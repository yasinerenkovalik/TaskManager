namespace CQRS_Test_Project.Core.Application.Features.Queries.Task.GetByUserIdTask;

public class GetByUserIdTaskQuertResponse
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string Priority { get; set; }
    public string Status { get; set; }
    public Guid ProjectId { get; set; }
    public Guid UserId { get; set; }
}
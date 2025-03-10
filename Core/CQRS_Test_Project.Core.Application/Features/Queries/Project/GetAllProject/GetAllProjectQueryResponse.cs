namespace CQRS_Test_Project.Core.Application.Features.Queries.Project.GetAllProject;

public class GetAllProjectQueryResponse
{
    public Guid UserId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
}
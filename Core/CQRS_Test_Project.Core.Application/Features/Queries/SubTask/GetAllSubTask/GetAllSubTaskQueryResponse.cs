namespace CQRS_Test_Project.Core.Application.Features.Queries.SubTask.GetAllSubTask;

public class GetAllSubTaskQueryResponse
{
    
    public Guid TaskId { get; set; }
    public string Title { get; set; }
    public string Status { get; set; }
    public string Description { get; set; }
    public Guid UserId { get; set; }

}
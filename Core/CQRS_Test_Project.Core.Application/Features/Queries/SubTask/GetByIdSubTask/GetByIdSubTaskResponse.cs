namespace CQRS_Test_Project.Core.Application.Features.Queries.SubTask.GetByIdSubTask;

public class GetByIdSubTaskResponse
{
    public Guid TaskId { get; set; }
    public string TaskName { get; set; }
    public string Title { get; set; }
    public string Status { get; set; }
    public string Description { get; set; }
    public string UserName { get; set; }
}
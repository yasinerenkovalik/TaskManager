namespace CQRS_Test_Project.Core.Application.Features.Commands.SubTask.CreateSubTag;

public class CreateSubTaskCommandResponse
{
    public string Title { get; set; }
    public string Status { get; set; }
    public string Description { get; set; }
    public Guid UserId { get; set; }
}
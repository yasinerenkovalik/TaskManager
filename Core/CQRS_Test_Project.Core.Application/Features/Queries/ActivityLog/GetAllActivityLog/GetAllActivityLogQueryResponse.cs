namespace CQRS_Test_Project.Core.Application.Features.Queries.ActivityLog.GetAllActivityLog;

public class GetAllActivityLogQueryResponse
{
    public Guid TaskId { get; set; }  
    public Guid UserId { get; set; }
    public string Action { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }

}
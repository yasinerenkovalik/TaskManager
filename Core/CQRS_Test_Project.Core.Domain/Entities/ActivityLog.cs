using CQRS_Test_Project.Core.Domain.Entities.Base;

namespace CQRS_Test_Project.Core.Domain.Entities;

public class ActivityLog:BaseEntity
{
    public Guid TaskId { get; set; }  
    public Guid UserId { get; set; }
    public string Action { get; set; }	
        
}
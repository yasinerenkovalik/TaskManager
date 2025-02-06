using CQRS_Test_Project.Core.Domain.Entities.Base;

namespace CQRS_Test_Project.Core.Domain.Entities;

public class Feedback: BaseEntity
{
    public Guid UserId { get; set; }
    public string Message { get; set; }
    
}
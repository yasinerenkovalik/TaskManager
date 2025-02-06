using CQRS_Test_Project.Core.Domain.Entities.Base;

namespace CQRS_Test_Project.Core.Domain.Entities;

public class TaskTag:BaseEntity
{
    public Guid TaskId { get; set; }
    public Guid TagId { get; set; }
}
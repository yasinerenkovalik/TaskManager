using CQRS_Test_Project.Core.Domain.Entities.Base;

namespace CQRS_Test_Project.Core.Domain.Entities;

public class Workflow:BaseEntity
{
    public Guid TaskId { get; set; }
    public string Stage { get; set; }
}
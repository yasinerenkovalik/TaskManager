using CQRS_Test_Project.Core.Domain.Entities.Base;

namespace CQRS_Test_Project.Core.Domain.Entities;

public class SubTask:BaseEntity
{
    public Guid TaskId { get; set; }
    public string Title { get; set; }
    public string Status { get; set; }
}
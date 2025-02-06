using CQRS_Test_Project.Core.Domain.Entities.Base;

namespace CQRS_Test_Project.Core.Domain.Entities;

public class Project:BaseEntity
{
    public Guid UserId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
}
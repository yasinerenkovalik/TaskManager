using CQRS_Test_Project.Core.Domain.Entities.Base;

namespace CQRS_Test_Project.Core.Domain.Entities;

public class TeamMember:BaseEntity
{
    public Guid TeamId { get; set; }
    public Guid UserId { get; set; }
    public string Role { get; set; }
}
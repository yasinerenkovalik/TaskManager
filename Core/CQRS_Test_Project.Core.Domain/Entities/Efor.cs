using CQRS_Test_Project.Core.Domain.Entities.Base;

namespace CQRS_Test_Project.Core.Domain.Entities;

public class Efor:BaseEntity
{
    public Guid UserId { get; set; }
    public Guid SubTaskId { get; set; }
    public double EforHour { get; set; }
}
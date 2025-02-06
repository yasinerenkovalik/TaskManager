using CQRS_Test_Project.Core.Domain.Entities.Base;

namespace CQRS_Test_Project.Core.Domain.Entities;

public class Tag:BaseEntity
{
    public string Name { get; set; }
}
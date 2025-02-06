using CQRS_Test_Project.Core.Domain.Entities.Base;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CQRS_Test_Project.Core.Domain.Entities;

public class Team:BaseEntity
{
    public string TeamName { get; set; }
    public Guid CreatedBy { get; set; }
}
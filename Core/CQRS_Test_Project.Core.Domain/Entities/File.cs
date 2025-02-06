using CQRS_Test_Project.Core.Domain.Entities.Base;

namespace CQRS_Test_Project.Core.Domain.Entities;

public class File:BaseEntity
{
    public Guid TaskId { get; set; }
    public string FileName { get; set; }
    public string FilePath { get; set; }
    public Guid UploadedBy { get; set; }
}
namespace CQRS_Test_Project.Core.Application.Features.Queries.File.GetAllFile;

public class GetAllFileQueryResponse
{
    public Guid TaskId { get; set; }
    public string FileName { get; set; }
    public string FilePath { get; set; }
    public Guid UploadedBy { get; set; }
}
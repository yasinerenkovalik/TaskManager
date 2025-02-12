using CQRS_Test_Project.Core.Application.Wrappers;
using MediatR;

namespace CQRS_Test_Project.Core.Application.Features.Commands.File.UpdateFile;

public class UpdateFileCommandRequest: IRequest<GeneralResponse<UpdateFileCommandResponse>>
{
   
    public Guid Id { get; set; }
    public Guid TaskId { get; set; }
    public string FileName { get; set; }
    public string FilePath { get; set; }
    public Guid UploadedBy { get; set; }
}
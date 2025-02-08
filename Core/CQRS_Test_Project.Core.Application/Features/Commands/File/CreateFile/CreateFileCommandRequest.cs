using CQRS_Test_Project.Core.Application.Wrappers;
using MediatR;

namespace CQRS_Test_Project.Core.Application.Features.Commands.File.CreateFile;

public class CreateFileCommandRequest:IRequest<GeneralResponse<CreateFileCommandResponse>>
{
    public Guid TaskId { get; set; }
    public string FileName { get; set; }
    public string FilePath { get; set; }
    public Guid UploadedBy { get; set; }
}
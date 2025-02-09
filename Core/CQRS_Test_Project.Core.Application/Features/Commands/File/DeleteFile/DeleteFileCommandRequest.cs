using CQRS_Test_Project.Core.Application.Wrappers;
using MediatR;

namespace CQRS_Test_Project.Core.Application.Features.Commands.File.DeleteFile;

public class DeleteFileCommandRequest:IRequest<GeneralResponse<DeleteFileCommandResponse>>
{
    public Guid Id { get; set; }
}
using CQRS_Test_Project.Core.Application.Wrappers;
using MediatR;

namespace CQRS_Test_Project.Core.Application.Features.Commands.SubTask.DeleteSubTag;

public class DeleteSubTaskCommandRequest:IRequest<GeneralResponse<DeleteSubTaskCommandResponse>>
{
    public Guid Id { get; set; }
}
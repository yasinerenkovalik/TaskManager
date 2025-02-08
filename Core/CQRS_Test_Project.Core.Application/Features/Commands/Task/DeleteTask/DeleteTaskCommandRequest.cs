using CQRS_Test_Project.Core.Application.Wrappers;
using MediatR;

namespace CQRS_Test_Project.Core.Application.Features.Commands.Task.DeleteTask;

public class DeleteTaskCommandRequest:IRequest<GeneralResponse<DeleteTaskCommandResponse>>
{
   public Guid Id { get; set; }
}
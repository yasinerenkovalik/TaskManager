using CQRS_Test_Project.Core.Application.Wrappers;
using MediatR;

namespace CQRS_Test_Project.Core.Application.Features.Commands.Project.DeleteProject;

public class DeleteProjectCommandRequest:IRequest<GeneralResponse<DeleteProjectCommandResponse>>
{
    public Guid Id { get; set; }
}
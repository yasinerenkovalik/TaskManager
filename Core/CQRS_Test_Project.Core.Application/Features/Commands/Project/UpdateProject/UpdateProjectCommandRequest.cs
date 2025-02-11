using CQRS_Test_Project.Core.Application.Wrappers;
using MediatR;

namespace CQRS_Test_Project.Core.Application.Features.Commands.Project.UpdateProject;

public class UpdateProjectCommandRequest:IRequest<GeneralResponse<UpdateProjectCommandResponse>>
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
}
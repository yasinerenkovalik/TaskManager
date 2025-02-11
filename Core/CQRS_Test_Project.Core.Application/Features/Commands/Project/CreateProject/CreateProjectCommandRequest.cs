using CQRS_Test_Project.Core.Application.Wrappers;
using MediatR;

namespace CQRS_Test_Project.Core.Application.Features.Commands.Project.CreateProject;

public class CreateProjectCommandRequest:IRequest<GeneralResponse<CreateProjectCommandResponse>>
{
    public Guid UserId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
}
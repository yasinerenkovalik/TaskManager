using CQRS_Test_Project.Core.Application.Features.Commands.Team.DeleteTeam;
using CQRS_Test_Project.Core.Application.Features.Commands.User.DeleteUser;
using CQRS_Test_Project.Core.Application.Wrappers;
using MediatR;

namespace CQRS_Test_Project.Core.Application.Features.Commands.Team.CreateTeam;

public class CreateTeamCommandRequest:IRequest<GeneralResponse<CreateTeamCommandResponse>>
{
    public string TeamName { get; set; }
    public Guid CreatedBy { get; set; }
}
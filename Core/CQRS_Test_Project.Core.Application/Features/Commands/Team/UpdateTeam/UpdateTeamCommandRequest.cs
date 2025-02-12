using CQRS_Test_Project.Core.Application.Wrappers;
using MediatR;

namespace CQRS_Test_Project.Core.Application.Features.Commands.Team.UpdateTeam;

public class UpdateTeamCommandRequest:IRequest<GeneralResponse<UpdateTeamCommandResponse>>
{
    public Guid Id { get; set; }
    public string TeamName { get; set; }
    public Guid CreatedBy { get; set; }
}
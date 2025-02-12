using CQRS_Test_Project.Core.Application.Wrappers;
using MediatR;

namespace CQRS_Test_Project.Core.Application.Features.Commands.Team.DeleteTeam;

public class DeleteTeamCommandRequest:IRequest<GeneralResponse<DeleteTeamCommandResponse>>
{
    public Guid Id { get; set; }
}
using CQRS_Test_Project.Core.Application.Wrappers;
using MediatR;

namespace CQRS_Test_Project.Core.Application.Features.Commands.TeamMember.CreateTeamMember;

public class CreateTeamMemberCommandRequest:IRequest<GeneralResponse<CreateTeamMemberCommandResponse>>
{
    public Guid TeamId { get; set; }
    public Guid UserId { get; set; }
    public string Role { get; set; }
}
using CQRS_Test_Project.Core.Application.Wrappers;
using MediatR;

namespace CQRS_Test_Project.Core.Application.Features.Commands.TeamMember.UpdateTeamMember;

public class UpdateTeamMemberCommandRequest:IRequest<GeneralResponse<UpdateTeamMemberCommandResponse>>
{
    public Guid Id { get; set; }
    public Guid TeamId { get; set; }
    public Guid UserId { get; set; }
    public string Role { get; set; }
}
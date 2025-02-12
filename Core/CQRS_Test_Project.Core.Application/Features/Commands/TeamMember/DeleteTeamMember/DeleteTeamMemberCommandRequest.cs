using CQRS_Test_Project.Core.Application.Wrappers;
using MediatR;

namespace CQRS_Test_Project.Core.Application.Features.Commands.TeamMember.DeleteTeamMember;

public class DeleteTeamMemberCommandRequest:IRequest<GeneralResponse<DeleteTeamMemberCommandResponse>>
{
    public Guid Id { get; set; }
}
using CQRS_Test_Project.Core.Application.Features.Commands.Team.CreateTeam;
using CQRS_Test_Project.Core.Application.Features.Commands.Team.DeleteTeam;
using CQRS_Test_Project.Core.Application.Features.Commands.Team.UpdateTeam;
using CQRS_Test_Project.Core.Application.Features.Commands.TeamMember.CreateTeamMember;
using CQRS_Test_Project.Core.Application.Features.Commands.TeamMember.DeleteTeamMember;
using CQRS_Test_Project.Core.Application.Features.Commands.TeamMember.UpdateTeamMember;
using FluentValidation;

namespace CQRS_Test_Project.Core.Application.Validations.TeamMember;

public class TeamMember
{
    public class CreateTeamMemberValidator : AbstractValidator<CreateTeamMemberCommandRequest>
    {
        public CreateTeamMemberValidator()
        {
           
        }
    }

    public class DeleteTeamMemberValidator : AbstractValidator<DeleteTeamMemberCommandRequest>
    {
        public DeleteTeamMemberValidator()
        {
            
        }
    }
    public class UpdateTeamMemberValidator : AbstractValidator<UpdateTeamMemberCommandRequest>
    {
        public UpdateTeamMemberValidator()
        {
           
        }
    }
}
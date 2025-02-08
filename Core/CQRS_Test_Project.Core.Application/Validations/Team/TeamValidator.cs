using CQRS_Test_Project.Core.Application.Features.Commands.Tag.CreateTag;
using CQRS_Test_Project.Core.Application.Features.Commands.Tag.DeleteTag;
using CQRS_Test_Project.Core.Application.Features.Commands.Tag.UpdateTag;
using CQRS_Test_Project.Core.Application.Features.Commands.Team.CreateTeam;
using CQRS_Test_Project.Core.Application.Features.Commands.Team.DeleteTeam;
using CQRS_Test_Project.Core.Application.Features.Commands.Team.UpdateTeam;
using FluentValidation;

namespace CQRS_Test_Project.Core.Application.Validations.Team;

public class TeamValidator
{
    public class CreateTeamValidator : AbstractValidator<CreateTeamCommandRequest>
    {
        public CreateTeamValidator()
        {
           
        }
    }

    public class DeleteTeamValidator : AbstractValidator<DeleteTeamCommandRequest>
    {
        public DeleteTeamValidator()
        {
            
        }
    }
    public class UpdateTeamValidator : AbstractValidator<UpdateTeamCommandRequest>
    {
        public UpdateTeamValidator()
        {
           
        }
    }
}
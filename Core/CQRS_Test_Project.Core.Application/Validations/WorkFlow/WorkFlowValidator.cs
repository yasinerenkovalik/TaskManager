using CQRS_Test_Project.Core.Application.Features.Commands.Team.CreateTeam;
using CQRS_Test_Project.Core.Application.Features.Commands.Team.DeleteTeam;
using CQRS_Test_Project.Core.Application.Features.Commands.Team.UpdateTeam;
using CQRS_Test_Project.Core.Application.Features.Commands.WorkFlow.CreateWorkFlow;
using CQRS_Test_Project.Core.Application.Features.Commands.WorkFlow.DeleteWorkFlow;
using CQRS_Test_Project.Core.Application.Features.Commands.WorkFlow.UpdateWorkFlow;
using FluentValidation;

namespace CQRS_Test_Project.Core.Application.Validations.WorkFlow;

public class WorkFlowValidator
{
    public class CreateWorkFlowValidator : AbstractValidator<CreateWorkFlowCommandRequest>
    {
        public CreateWorkFlowValidator()
        {
           
        }
    }

    public class DeleteWorkFlowValidator : AbstractValidator<DeleteWorkFlowCommandRequest>
    {
        public DeleteWorkFlowValidator()
        {
            
        }
    }
    public class UpdateWorkFlowValidator : AbstractValidator<UpdateWorkFlowCommandRequest>
    {
        public UpdateWorkFlowValidator()
        {
           
        }
    }
}
using CQRS_Test_Project.Core.Application.Features.Commands.ActivityLog.CreateActivityLog;
using CQRS_Test_Project.Core.Application.Features.Commands.ActivityLog.DeleteActivityLog;
using CQRS_Test_Project.Core.Application.Features.Commands.ActivityLog.UpdateActivityLog;
using FluentValidation;

namespace CQRS_Test_Project.Core.Application.Validations.ActivityLog
{
    public class ActivityLogValidator : AbstractValidator<CreateActivityLogCommandRequest>
    {
        public ActivityLogValidator()
        {
            RuleFor(x => x.Action).NotEmpty();
        }
    }

    public class DeleteActivityLogValidator : AbstractValidator<DeleteActivityLogCommandRequest>
    {
        public DeleteActivityLogValidator()
        {
            RuleFor(x => x.Id).NotEmpty(); 
        }
    }
    public class UpdateActivityLogValidator : AbstractValidator<UpdateActivityLogCommandRequest>
    {
        public UpdateActivityLogValidator()
        {
            RuleFor(x => x.Action).NotEmpty(); 
        }
    }
}


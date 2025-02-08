using CQRS_Test_Project.Core.Application.Features.Commands.ActivityLog.UpdateActivityLog;
using FluentValidation;

namespace CQRS_Test_Project.Core.Application.Validations.ActivityLog;

public class UpdateActivityLogValidator:AbstractValidator<UpdateActivityLogCommandRequest>
{
    public UpdateActivityLogValidator()
    {
        RuleFor(x=>x.UserId)
            .NotEmpty().WithMessage("UserId cannot be empty");
    }
}
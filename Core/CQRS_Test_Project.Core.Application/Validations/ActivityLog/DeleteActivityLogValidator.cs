using CQRS_Test_Project.Core.Application.Features.Commands.ActivityLog.DeleteActivityLog;
using FluentValidation;

namespace CQRS_Test_Project.Core.Application.Validations.ActivityLog;

public class DeleteActivityLogValidator:AbstractValidator<DeleteActivityLogCommandRequest>
{
    public DeleteActivityLogValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
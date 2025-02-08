using CQRS_Test_Project.Core.Application.Features.Commands.ActivityLog.CreateActivityLog;
using FluentValidation;

namespace CQRS_Test_Project.Core.Application.Validations.ActivityLog;

public class CreateActivityLogCommandRequestValidator : AbstractValidator<CreateActivityLogCommandRequest>
{
    public CreateActivityLogCommandRequestValidator()
    {
        RuleFor(x => x.Action)
            .NotEmpty().WithMessage("Aksiyon adı boş olamaz.")
            .Length(3, 50).WithMessage("Aksiyon adı 3 ile 50 karakter arasında olmalıdır.");
    }
}
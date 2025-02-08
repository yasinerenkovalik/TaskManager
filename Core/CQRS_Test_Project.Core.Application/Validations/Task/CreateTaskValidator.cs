using CQRS_Test_Project.Core.Application.Features.Commands.Task.CreateTask;
using FluentValidation;

namespace CQRS_Test_Project.Core.Application.Validations.Task;

public class CreateTaskCommandRequestValidator:AbstractValidator<CreateTaskCommanRequest>
{
    public CreateTaskCommandRequestValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Aksiyon adı boş olamaz.")
            .Length(3, 50).WithMessage("Aksiyon adı 3 ile 50 karakter arasında olmalıdır.");
    }
}
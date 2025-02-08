using CQRS_Test_Project.Core.Application.Features.Commands.Task.DeleteTask;
using FluentValidation;

namespace CQRS_Test_Project.Core.Application.Validations.Task;

public class DeleteTaskValidator:AbstractValidator<DeleteTaskCommandRequest>
{
    public DeleteTaskValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("Id Boş Olamaz");
    }
}
using CQRS_Test_Project.Core.Application.Features.Commands.Task.UpdateTask;
using FluentValidation;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace CQRS_Test_Project.Core.Application.Validations.Task;

public class UpdateTaskValidator:AbstractValidator<UpdateTaskCommandRequest>
{
    public UpdateTaskValidator()
    {
        RuleFor(x => x.Title).NotEmpty();
    }
}
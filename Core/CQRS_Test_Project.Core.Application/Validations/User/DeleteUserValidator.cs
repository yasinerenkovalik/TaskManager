using CQRS_Test_Project.Core.Application.Features.Commands.User.CreateUser;
using CQRS_Test_Project.Core.Application.Features.Commands.User.DeleteUser;
using FluentValidation;

namespace CQRS_Test_Project.Core.Application.Validations.User;

public class DeleteUserValidator:AbstractValidator<DeleteUserCommanRequest>
{
    public DeleteUserValidator()
    {

        RuleFor(x => x.UserId)
            .NotEmpty().WithMessage("UserId boş olamaz.");
        
    }
}

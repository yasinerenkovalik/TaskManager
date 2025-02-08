using CQRS_Test_Project.Core.Application.Features.Commands.User.CreateUser;
using CQRS_Test_Project.Core.Application.Features.Commands.User.DeleteUser;
using CQRS_Test_Project.Core.Application.Features.Commands.User.UpdateUser;
using FluentValidation;

namespace CQRS_Test_Project.Core.Application.Validations.User
{
    public class UserValidator : AbstractValidator<CreateUserCommandRequest>
    {
        public UserValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
        }
    }

    public class DeleteUserValidator : AbstractValidator<DeleteUserCommanRequest>
    {
        public DeleteUserValidator()
        {
            RuleFor(x => x.UserId).NotEmpty(); 
        }
    }
    public class UpdateUserValidator : AbstractValidator<UpdateUserCommandRequest>
    {
        public UpdateUserValidator()
        {
            RuleFor(x => x.Name).NotEmpty(); 
        }
    }
}

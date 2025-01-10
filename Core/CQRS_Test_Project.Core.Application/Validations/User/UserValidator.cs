using CQRS_Test_Project.Core.Application.Features.Commands.User.CreateUser;
using FluentValidation;

namespace CQRS_Test_Project.Core.Application.Validations.User
{
    public class CreateUserCommandRequestValidator : AbstractValidator<CreateUserCommandRequest>
    {
        public CreateUserCommandRequestValidator()
        {

        }

    }
}

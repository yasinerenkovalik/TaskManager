using CQRS_Test_Project.Core.Application.Features.Commands.User.CreateUser;
using FluentValidation;

namespace CQRS_Test_Project.Core.Application.Validations.User
{
    public class CreateUserCommandRequestValidator : AbstractValidator<CreateUserCommandRequest>
    {
        public CreateUserCommandRequestValidator()
        {
            RuleFor(x => x.Username)
                .NotEmpty().WithMessage("Kullanıcı adı boş olamaz.")
                .Length(3, 50).WithMessage("Kullanıcı adı 3 ile 50 karakter arasında olmalıdır.");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("İsim alanı boş olamaz.")
                .Length(3, 50).WithMessage("İsim alanı 3 ile 50 karakter arasında olmalıdır."); ;
            
        }
    }
}

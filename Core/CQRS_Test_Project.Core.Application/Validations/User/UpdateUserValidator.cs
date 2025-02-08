using CQRS_Test_Project.Core.Application.Features.Commands.User.UpdateUser;
using FluentValidation;

namespace CQRS_Test_Project.Core.Application.Validations.User;

public class UpdateUserValidator : AbstractValidator<UpdateUserCommandRequest>
{
    public UpdateUserValidator()
    {
        RuleFor(x => x.Username)
            .NotEmpty().WithMessage("Kullanıcı adı boş olamaz.")
            .Length(3, 50).WithMessage("Kullanıcı adı 3 ile 50 karakter arasında olmalıdır.");

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("İsim alanı boş olamaz.")
            .Length(3, 50).WithMessage("İsim alanı 3 ile 50 karakter arasında olmalıdır."); ;
            
    }
}
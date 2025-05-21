using CQRS_Test_Project.Core.Application.Features.Commands.Efor.CreateEfor;
using FluentValidation;

namespace CQRS_Test_Project.Core.Application.Validations.Efor;

public class EforValidator:AbstractValidator<CreateEforRequest>
{
    public EforValidator()
    {
        RuleFor(x => x.UserId).NotEmpty();
    }
}
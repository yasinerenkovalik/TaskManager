using CQRS_Test_Project.Core.Application.Features.Commands.FeedBack.CreateFeedBack;
using FluentValidation;

namespace CQRS_Test_Project.Core.Application.Validations.FeedBack;

public class CreateFeedBackValidator:AbstractValidator<CreateFeedBackCommandRequest>
{
    public CreateFeedBackValidator()
    {
        RuleFor(x=>x.Message).NotEmpty();
    }
}
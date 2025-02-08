using CQRS_Test_Project.Core.Application.Features.Commands.FeedBack.DeleteFeedBack;
using FluentValidation;

namespace CQRS_Test_Project.Core.Application.Validations.FeedBack;

public class DeleteFeedBackValidator:AbstractValidator<DeleteFeedBackCommandRequest>
{
    public DeleteFeedBackValidator()
    {
        RuleFor(x => x.GetType()).NotEmpty();
    }
}
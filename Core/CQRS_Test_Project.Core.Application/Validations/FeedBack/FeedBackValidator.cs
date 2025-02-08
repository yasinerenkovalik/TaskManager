using CQRS_Test_Project.Core.Application.Features.Commands.FeedBack.CreateFeedBack;
using CQRS_Test_Project.Core.Application.Features.Commands.FeedBack.DeleteFeedBack;
using CQRS_Test_Project.Core.Application.Features.Commands.FeedBack.UpdateFeedBack;
using FluentValidation;

namespace CQRS_Test_Project.Core.Application.Validations.FeedBack
{
    public class FeedBackValidator : AbstractValidator<CreateFeedBackCommandRequest>
    {
        public FeedBackValidator()
        {
            RuleFor(x => x.Message).NotEmpty();
        }
    }

    public class DeleteFeedBackValidator : AbstractValidator<DeleteFeedBackCommandRequest>
    {
        public DeleteFeedBackValidator()
        {
            RuleFor(x => x.Id).NotEmpty(); // x.GetType() yanlış, x.Id kullanmalısın.
        }
    }
    public class UpdateFeedBackValidator : AbstractValidator<UpdateFeedBackCommandRequest>
    {
        public UpdateFeedBackValidator()
        {
            RuleFor(x => x.Id).NotEmpty(); // x.GetType() yanlış, x.Id kullanmalısın.
        }
    }
}
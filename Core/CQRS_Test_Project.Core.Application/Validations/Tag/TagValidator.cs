using CQRS_Test_Project.Core.Application.Features.Commands.SubTask.CreateSubTag;
using CQRS_Test_Project.Core.Application.Features.Commands.SubTask.DeleteSubTag;
using CQRS_Test_Project.Core.Application.Features.Commands.SubTask.UpdateSubTag;
using CQRS_Test_Project.Core.Application.Features.Commands.Tag.CreateTag;
using CQRS_Test_Project.Core.Application.Features.Commands.Tag.DeleteTag;
using CQRS_Test_Project.Core.Application.Features.Commands.Tag.UpdateTag;
using FluentValidation;

namespace CQRS_Test_Project.Core.Application.Validations.Tag;

public class TagValidator
{
    public class CreateTagValidator : AbstractValidator<CreateTagCommandRequest>
    {
        public CreateTagValidator()
        {
           
        }
    }

    public class DeleteTagValidator : AbstractValidator<DeleteTagCommandRequest>
    {
        public DeleteTagValidator()
        {
            
        }
    }
    public class UpdateTagValidator : AbstractValidator<UpdateTagCommandRequest>
    {
        public UpdateTagValidator()
        {
           
        }
    }
}
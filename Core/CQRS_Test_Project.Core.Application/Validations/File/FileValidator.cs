using CQRS_Test_Project.Core.Application.Features.Commands.FeedBack.CreateFeedBack;
using CQRS_Test_Project.Core.Application.Features.Commands.FeedBack.DeleteFeedBack;
using CQRS_Test_Project.Core.Application.Features.Commands.FeedBack.UpdateFeedBack;
using CQRS_Test_Project.Core.Application.Features.Commands.File.CreateFile;
using CQRS_Test_Project.Core.Application.Features.Commands.File.DeleteFile;
using CQRS_Test_Project.Core.Application.Features.Commands.File.UpdateFile;
using FluentValidation;

namespace CQRS_Test_Project.Core.Application.Validations.File;

public class FileValidator
{
    public class CreateFileValidator : AbstractValidator<CreateFileCommandRequest>
    {
        public CreateFileValidator()
        {
           
        }
    }

    public class DeleteFileValidator : AbstractValidator<DeleteFileCommandRequest>
    {
        public DeleteFileValidator()
        {
            
        }
    }
    public class UpdateFileValidator : AbstractValidator<UpdateFileCommandRequest>
    {
        public UpdateFileValidator()
        {
           
        }
    }
}
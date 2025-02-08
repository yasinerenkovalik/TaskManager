using CQRS_Test_Project.Core.Application.Features.Commands.Project.CreateProject;
using CQRS_Test_Project.Core.Application.Features.Commands.Project.DeleteProject;
using CQRS_Test_Project.Core.Application.Features.Commands.Project.UpdateProject;
using CQRS_Test_Project.Core.Application.Features.Commands.SubTask.CreateSubTag;
using CQRS_Test_Project.Core.Application.Features.Commands.SubTask.DeleteSubTag;
using CQRS_Test_Project.Core.Application.Features.Commands.SubTask.UpdateSubTag;
using FluentValidation;

namespace CQRS_Test_Project.Core.Application.Validations.SubTask;

public class SubTaskValidator
{
    public class CreateSubTaskValidator : AbstractValidator<CreateSubTaskCommandRequest>
    {
        public CreateSubTaskValidator()
        {
           
        }
    }

    public class DeleteSubTaskValidator : AbstractValidator<DeleteSubTaskCommandRequest>
    {
        public DeleteSubTaskValidator()
        {
            
        }
    }
    public class UpdateSubTaskValidator : AbstractValidator<UpdateSubTaskCommandRequest>
    {
        public UpdateSubTaskValidator()
        {
           
        }
    }
}
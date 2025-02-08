using CQRS_Test_Project.Core.Application.Features.Commands.File.CreateFile;
using CQRS_Test_Project.Core.Application.Features.Commands.File.DeleteFile;
using CQRS_Test_Project.Core.Application.Features.Commands.File.UpdateFile;
using CQRS_Test_Project.Core.Application.Features.Commands.Project.CreateProject;
using CQRS_Test_Project.Core.Application.Features.Commands.Project.DeleteProject;
using CQRS_Test_Project.Core.Application.Features.Commands.Project.UpdateProject;
using FluentValidation;

namespace CQRS_Test_Project.Core.Application.Validations.Project;

public class ProjectValidator
{
    public class CreateProjectValidator : AbstractValidator<CreateProjectCommandRequest>
    {
        public CreateProjectValidator()
        {
           
        }
    }

    public class DeleteProjecteValidator : AbstractValidator<DeleteProjectCommandRequest>
    {
        public DeleteProjecteValidator()
        {
            
        }
    }
    public class UpdateProjectValidator : AbstractValidator<UpdateProjectCommandRequest>
    {
        public UpdateProjectValidator()
        {
           
        }
    }
}
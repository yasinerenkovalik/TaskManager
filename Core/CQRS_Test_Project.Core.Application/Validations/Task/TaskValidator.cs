using CQRS_Test_Project.Core.Application.Features.Commands.Task.CreateTask;
using CQRS_Test_Project.Core.Application.Features.Commands.Task.DeleteTask;
using CQRS_Test_Project.Core.Application.Features.Commands.Task.UpdateTask;
using FluentValidation;

namespace CQRS_Test_Project.Core.Application.Validations.Task
{
    public class TaskValidator : AbstractValidator<CreateTaskCommanRequest>
    {
        public TaskValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Kullanıcı adı boş olamaz.")
                .Length(3, 50).WithMessage("Kullanıcı adı 3 ile 50 karakter arasında olmalıdır.");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("İsim alanı boş olamaz.")
                .Length(3, 50).WithMessage("İsim alanı 3 ile 50 karakter arasında olmalıdır."); ;

        }
    }

    public class DeleteTaskValidator : AbstractValidator<DeleteTaskCommandRequest>
    {
        public DeleteTaskValidator()
        {
            RuleFor(x => x.Id).NotEmpty(); 
        }
    }
    public class UpdateTaskValidator : AbstractValidator<UpdateTaskCommandRequest>
    {
        public UpdateTaskValidator()
        {
            RuleFor(x => x.Title).NotEmpty(); 
        }
    }
    
}


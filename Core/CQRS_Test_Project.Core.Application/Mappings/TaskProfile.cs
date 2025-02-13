using AutoMapper;
using CQRS_Test_Project.Core.Application.Features.Commands.Task.CreateTask;
using CQRS_Test_Project.Core.Application.Features.Commands.Task.DeleteTask;
using CQRS_Test_Project.Core.Application.Features.Commands.Task.UpdateTask;
using Task = CQRS_Test_Project.Core.Domain.Entities.Task;

namespace CQRS_Test_Project.Core.Application.Mappings;

public class TaskProfile:Profile
{
    public TaskProfile()
    {
        CreateMap<CreateTaskCommanRequest, Task>().ReverseMap();
        CreateMap<UpdateTaskCommandRequest, Task>().ReverseMap();
        CreateMap<DeleteTaskCommandRequest, Task>().ReverseMap();
    }
}
using AutoMapper;
using CQRS_Test_Project.Core.Application.Features.Commands.Task.CreateTask;
using Task = CQRS_Test_Project.Core.Domain.Entities.Task;

namespace CQRS_Test_Project.Core.Application.Mappings;

public class TaskProfile:Profile
{
    public TaskProfile()
    {
        CreateMap<CreateTaskCommanRequest, Task>().ReverseMap();
    }
}
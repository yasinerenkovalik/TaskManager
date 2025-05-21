using AutoMapper;
using CQRS_Test_Project.Core.Application.Features.Commands.Task.CreateTask;
using CQRS_Test_Project.Core.Application.Features.Commands.Task.DeleteTask;
using CQRS_Test_Project.Core.Application.Features.Commands.Task.UpdateTask;
using CQRS_Test_Project.Core.Application.Features.Queries.File.GetByIdFile;
using CQRS_Test_Project.Core.Application.Features.Queries.Task.GetAllTask;
using CQRS_Test_Project.Core.Application.Features.Queries.Task.GetByProjectTask;
using Task = CQRS_Test_Project.Core.Domain.Entities.Task;

namespace CQRS_Test_Project.Core.Application.Mappings;

public class TaskProfile:Profile
{
    public TaskProfile()
    {
        CreateMap<CreateTaskCommanRequest, Task>().ReverseMap();
        CreateMap<UpdateTaskCommandRequest, Task>().ReverseMap();
        CreateMap<DeleteTaskCommandRequest, Task>().ReverseMap();
        CreateMap<GetAllTaskQueryResponse, Task>().ReverseMap();
        CreateMap<GetByProjectTaskRequest, Task>().ReverseMap();
        CreateMap<GetByProjectTaskResponse, Task>().ReverseMap();
 
    }
}
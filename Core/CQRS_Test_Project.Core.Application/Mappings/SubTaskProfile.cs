using AutoMapper;
using CQRS_Test_Project.Core.Application.Features.Commands.SubTask.CreateSubTag;
using CQRS_Test_Project.Core.Application.Features.Commands.SubTask.DeleteSubTag;
using CQRS_Test_Project.Core.Application.Features.Commands.SubTask.UpdateSubTag;
using CQRS_Test_Project.Core.Application.Features.Queries.SubTask.GetAllSubTask;
using CQRS_Test_Project.Core.Application.Features.Queries.SubTask.GetByIdSubTask;
using CQRS_Test_Project.Core.Application.Features.Queries.SubTask.GetByTaskSubTask;
using CQRS_Test_Project.Core.Domain.Entities;

namespace CQRS_Test_Project.Core.Application.Mappings;

public class SubTaskProfile:Profile
{
    public SubTaskProfile()
    {
        CreateMap<CreateSubTaskCommandRequest, SubTask>().ReverseMap();
        CreateMap<UpdateSubTaskCommandRequest, SubTask>().ReverseMap();
        CreateMap<DeleteSubTaskCommandRequest, SubTask>().ReverseMap();
        CreateMap<GetAllSubTaskQueryResponse, SubTask>().ReverseMap();
        CreateMap<SubTask, UpdateSubTaskCommandResponse>();
     
        CreateMap<SubTask, GetByTaskSubTaskResponse>().ReverseMap();
        
        
    }
}
using AutoMapper;
using CQRS_Test_Project.Core.Application.Features.Commands.SubTask.CreateSubTag;
using CQRS_Test_Project.Core.Application.Features.Commands.SubTask.DeleteSubTag;
using CQRS_Test_Project.Core.Application.Features.Commands.WorkFlow.UpdateWorkFlow;
using CQRS_Test_Project.Core.Domain.Entities;

namespace CQRS_Test_Project.Core.Application.Mappings;

public class SubTaskProfile:Profile
{
    public SubTaskProfile()
    {
        CreateMap<CreateSubTaskCommandRequest, SubTask>().ReverseMap();
        CreateMap<UpdateWorkFlowCommandRequest, SubTask>().ReverseMap();
        CreateMap<DeleteSubTaskCommandRequest, SubTask>().ReverseMap();
    }
}
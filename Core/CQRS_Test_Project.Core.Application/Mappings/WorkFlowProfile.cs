using AutoMapper;
using CQRS_Test_Project.Core.Application.Features.Commands.WorkFlow.CreateWorkFlow;
using CQRS_Test_Project.Core.Application.Features.Commands.WorkFlow.DeleteWorkFlow;
using CQRS_Test_Project.Core.Application.Features.Commands.WorkFlow.UpdateWorkFlow;
using CQRS_Test_Project.Core.Domain.Entities;

namespace CQRS_Test_Project.Core.Application.Mappings;

public class WorkFlowProfile:Profile
{
    public WorkFlowProfile()
    {
        CreateMap<CreateWorkFlowCommandRequest, Workflow>();
        CreateMap<DeleteWorkFlowCommandRequest, Workflow>();
        CreateMap<UpdateWorkFlowCommandRequest, Workflow>();
    }
}
using AutoMapper;
using CQRS_Test_Project.Core.Application.Features.Commands.Project.CreateProject;
using CQRS_Test_Project.Core.Application.Features.Commands.Project.UpdateProject;
using CQRS_Test_Project.Core.Application.Features.Queries.Project.GetAllProject;
using CQRS_Test_Project.Core.Domain.Entities;

namespace CQRS_Test_Project.Core.Application.Mappings;

public class ProjectProfile:Profile
{
    public ProjectProfile()
    {
        CreateMap<CreateProjectCommandRequest, Project>().ReverseMap();
        CreateMap<UpdateProjectCommandRequest, Project>().ReverseMap();
        CreateMap<Project, Project>();
        CreateMap<GetAllProjectQueryResponse, Project>().ReverseMap();
        
    }
}
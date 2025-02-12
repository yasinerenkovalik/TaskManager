using AutoMapper;
using CQRS_Test_Project.Core.Application.Features.Commands.Team.CreateTeam;
using CQRS_Test_Project.Core.Application.Features.Commands.Team.DeleteTeam;
using CQRS_Test_Project.Core.Application.Features.Commands.Team.UpdateTeam;
using CQRS_Test_Project.Core.Domain.Entities;

namespace CQRS_Test_Project.Core.Application.Mappings;

public class TeamProfile:Profile
{
    public TeamProfile()
    {
        CreateMap<CreateTeamCommandRequest, Team>().ReverseMap();
        CreateMap<DeleteTeamCommandRequest, Team>().ReverseMap();
        CreateMap<UpdateTeamCommandRequest, Team>().ReverseMap();
    }
}
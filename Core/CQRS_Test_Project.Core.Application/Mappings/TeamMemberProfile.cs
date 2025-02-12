using AutoMapper;
using CQRS_Test_Project.Core.Application.Features.Commands.Team.DeleteTeam;
using CQRS_Test_Project.Core.Application.Features.Commands.Team.UpdateTeam;
using CQRS_Test_Project.Core.Application.Features.Commands.TeamMember.CreateTeamMember;
using CQRS_Test_Project.Core.Application.Validations.TeamMember;

namespace CQRS_Test_Project.Core.Application.Mappings;

public class TeamMemberProfile: Profile
{
    public TeamMemberProfile()
    {
        CreateMap<CreateTeamMemberCommandRequest, TeamMember>().ReverseMap();
        CreateMap<DeleteTeamCommandRequest, TeamMember>().ReverseMap();
        CreateMap<UpdateTeamCommandRequest, TeamMember>().ReverseMap();
    }
}
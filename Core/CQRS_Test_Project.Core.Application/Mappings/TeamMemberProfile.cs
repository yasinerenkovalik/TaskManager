using AutoMapper;
using CQRS_Test_Project.Core.Application.Features.Commands.TeamMember.CreateTeamMember;
using CQRS_Test_Project.Core.Application.Features.Commands.TeamMember.DeleteTeamMember;
using CQRS_Test_Project.Core.Application.Features.Commands.TeamMember.UpdateTeamMember;
using CQRS_Test_Project.Core.Domain.Entities;


namespace CQRS_Test_Project.Core.Application.Mappings;

public class TeamMemberProfile: Profile
{
    public TeamMemberProfile()
    {
        CreateMap<CreateTeamMemberCommandRequest, TeamMember>().ReverseMap();
        CreateMap<DeleteTeamMemberCommandRequest, TeamMember>().ReverseMap();
        CreateMap<UpdateTeamMemberCommandRequest, TeamMember>().ReverseMap();
    }
}
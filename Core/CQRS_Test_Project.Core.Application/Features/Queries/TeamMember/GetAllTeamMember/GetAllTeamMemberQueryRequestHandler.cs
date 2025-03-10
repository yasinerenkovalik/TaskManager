using AutoMapper;
using CQRS_Test_Project.Core.Application.Features.Queries.Team.GetAllTeam;
using CQRS_Test_Project.Core.Application.Interface.Repository;
using CQRS_Test_Project.Core.Application.Wrappers;
using MediatR;

namespace CQRS_Test_Project.Core.Application.Features.Queries.TeamMember.GetAllTeamMember;

public class GetAllTeamMemberQueryRequestHandler(ITeamMemberRepository teamMemberRepository, IMapper mapper):IRequestHandler<GetAllTeamMemberQueryRequest, GeneralResponse<List<GetAllTeamMemberQueryResponse>>>
{
    public async Task<GeneralResponse<List<GetAllTeamMemberQueryResponse>>> Handle(GetAllTeamMemberQueryRequest request, CancellationToken cancellationToken)
    {
        var teamMemberEntity = await teamMemberRepository.GetAllAysnc();

        if (teamMemberEntity == null)
        {
            return new GeneralResponse<List<GetAllTeamMemberQueryResponse>>
            {
                Data = null,
                Errors = new List<string> { "Team bulunamadı." },
                isSuccess = false
            };
        }
        
        var getAllTeamMemberQueryResponse = mapper.Map<List<GetAllTeamMemberQueryResponse>>(teamMemberEntity);

        return new GeneralResponse<List<GetAllTeamMemberQueryResponse>>
        {
            Data = getAllTeamMemberQueryResponse,
            Errors = null,
            isSuccess = true
        };
    }
}
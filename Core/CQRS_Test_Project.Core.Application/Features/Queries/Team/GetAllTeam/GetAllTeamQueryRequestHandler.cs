using AutoMapper;
using CQRS_Test_Project.Core.Application.Interface.Repository;
using CQRS_Test_Project.Core.Application.Wrappers;
using MediatR;

namespace CQRS_Test_Project.Core.Application.Features.Queries.Team.GetAllTeam;

public class GetAllTeamQueryRequestHandler(ITeamRepository teamRepository, IMapper mapper):IRequestHandler<GetAllTeamQueryRequest, GeneralResponse<List<GetAllTeamQueryResponse>>>
{
    public async Task<GeneralResponse<List<GetAllTeamQueryResponse>>> Handle(GetAllTeamQueryRequest request, CancellationToken cancellationToken)
    {
        var taskEntity = await teamRepository.GetAllAysnc();

        if (taskEntity == null)
        {
            return new GeneralResponse<List<GetAllTeamQueryResponse>>
            {
                Data = null,
                Errors = new List<string> { "Team bulunamadı." },
                isSuccess = false
            };
        }
        
        var getAllProjectQueryResponse = mapper.Map<List<GetAllTeamQueryResponse>>(taskEntity);

        return new GeneralResponse<List<GetAllTeamQueryResponse>>
        {
            Data = getAllProjectQueryResponse,
            Errors = null,
            isSuccess = true
        };
    }
}
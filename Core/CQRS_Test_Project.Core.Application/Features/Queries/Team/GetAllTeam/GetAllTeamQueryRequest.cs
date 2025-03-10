using CQRS_Test_Project.Core.Application.Wrappers;
using MediatR;

namespace CQRS_Test_Project.Core.Application.Features.Queries.Team.GetAllTeam;

public class GetAllTeamQueryRequest:IRequest<GeneralResponse<List<GetAllTeamQueryResponse>>>
{
    
}
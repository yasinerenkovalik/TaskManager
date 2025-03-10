using CQRS_Test_Project.Core.Application.Wrappers;
using MediatR;

namespace CQRS_Test_Project.Core.Application.Features.Queries.TeamMember.GetAllTeamMember;

public class GetAllTeamMemberQueryRequest:IRequest<GeneralResponse<List<GetAllTeamMemberQueryResponse>>>
{
    
}
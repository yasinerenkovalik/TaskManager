namespace CQRS_Test_Project.Core.Application.Features.Queries.TeamMember.GetAllTeamMember;

public class GetAllTeamMemberQueryResponse
{
    public Guid TeamId { get; set; }
    public Guid UserId { get; set; }
    public string Role { get; set; }
}
namespace CQRS_Test_Project.Core.Application.Features.Queries.Team.GetAllTeam;

public class GetAllTeamQueryResponse
{
    public string TeamName { get; set; }
    public Guid CreatedBy { get; set; }
}
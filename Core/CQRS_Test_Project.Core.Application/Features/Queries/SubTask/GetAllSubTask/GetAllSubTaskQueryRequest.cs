using CQRS_Test_Project.Core.Application.Wrappers;
using MediatR;

namespace CQRS_Test_Project.Core.Application.Features.Queries.SubTask.GetAllSubTask;

public class GetAllSubTaskQueryRequest:IRequest<GeneralResponse<List<GetAllSubTaskQueryResponse>>>
{
    
}
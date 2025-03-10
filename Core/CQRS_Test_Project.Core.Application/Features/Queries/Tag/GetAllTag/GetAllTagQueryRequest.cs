using CQRS_Test_Project.Core.Application.Features.Queries.SubTask.GetAllSubTask;
using CQRS_Test_Project.Core.Application.Wrappers;
using MediatR;

namespace CQRS_Test_Project.Core.Application.Features.Queries.Tag.GetAllTag;

public class GetAllTagQueryRequest:IRequest<GeneralResponse<List<GetAllTagQueryResponse>>>
{
    
}
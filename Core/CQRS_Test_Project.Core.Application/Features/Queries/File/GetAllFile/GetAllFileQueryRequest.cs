using CQRS_Test_Project.Core.Application.Wrappers;
using MediatR;

namespace CQRS_Test_Project.Core.Application.Features.Queries.File.GetAllFile;

public class GetAllFileQueryRequest:IRequest<GeneralResponse<List<GetAllFileQueryResponse>>>
{
    
}
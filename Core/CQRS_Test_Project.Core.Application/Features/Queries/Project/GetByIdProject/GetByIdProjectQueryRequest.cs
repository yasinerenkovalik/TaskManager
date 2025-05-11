using CQRS_Test_Project.Core.Application.Wrappers;
using MediatR;

namespace CQRS_Test_Project.Core.Application.Features.Queries.Project.GetByIdProject;

public class GetByIdProjectQueryRequest:IRequest<GeneralResponse<GetByIdProjectQueryResponse>>
{
    public Guid Id { get; set; }
}
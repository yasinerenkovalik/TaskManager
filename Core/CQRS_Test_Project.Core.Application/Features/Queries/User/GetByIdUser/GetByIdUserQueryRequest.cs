using CQRS_Test_Project.Core.Application.Wrappers;
using MediatR;

namespace CQRS_Test_Project.Core.Application.Features.Queries.User.GetByIdUser
{
    public class GetByIdUserQueryRequest : IRequest<GeneralResponse<GetByIdUserQueryResponse>>
    {
        public Guid Id { get; set; }
    }

}

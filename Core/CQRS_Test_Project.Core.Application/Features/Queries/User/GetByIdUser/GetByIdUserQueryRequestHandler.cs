using CQRS_Test_Project.Core.Application.Wrappers;
using MediatR;

namespace CQRS_Test_Project.Core.Application.Features.Queries.User.GetByIdUser
{
    public class GetByIdUserQueryRequestHandler : IRequestHandler<GetByIdUserQueryRequest,
       GeneralResponse<GetByIdUserQueryResponse>>
    {

        public async Task<GeneralResponse<GetByIdUserQueryResponse>> Handle(GetByIdUserQueryRequest request, CancellationToken cancellationToken)
        {

            var getByIdUserQueryResponse = new GetByIdUserQueryResponse
            {
                Id = Guid.NewGuid(),
                Age = Random.Shared.Next(0, 100),
                CreatedAt = DateTime.UtcNow.AddDays(-3),
                UpdatedAt = null,
                DeletedAt = null,
                Name = "Mahmut",
                Surname = "Taş",
                Username = "Mahmuttas11"
            };


            var generalResponse = new GeneralResponse<GetByIdUserQueryResponse>
            {
                Data = getByIdUserQueryResponse,
                Errors = null,
                isSuccess = true
            };

            return generalResponse;


        }

    }
}

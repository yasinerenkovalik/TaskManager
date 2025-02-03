using AutoMapper;
using CQRS_Test_Project.Core.Application.Wrappers;
using MediatR;
using CQRS_Test_Project.Core.Application.Interface.Repository;

namespace CQRS_Test_Project.Core.Application.Features.Queries.User.GetByIdUser
{
    public class GetByIdUserQueryRequestHandler : IRequestHandler<GetByIdUserQueryRequest,
       GeneralResponse<GetByIdUserQueryResponse>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetByIdUserQueryRequestHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<GeneralResponse<GetByIdUserQueryResponse>> Handle(GetByIdUserQueryRequest request, CancellationToken cancellationToken)
        {
            // Repository'den kullanıcıyı getir
            var userEntity = await _userRepository.GetByIdAsync(request.Id);

            if (userEntity == null)
            {
                return new GeneralResponse<GetByIdUserQueryResponse>
                {
                    Data = null,
                    Errors = new List<string> { "Kullanıcı bulunamadı." },
                    isSuccess = false
                };
            }

            // AutoMapper ile kullanıcı verisini response modeline map et
            var getByIdUserQueryResponse = _mapper.Map<GetByIdUserQueryResponse>(userEntity);

            return new GeneralResponse<GetByIdUserQueryResponse>
            {
                Data = getByIdUserQueryResponse,
                Errors = null,
                isSuccess = true
            };
        }
    }
}

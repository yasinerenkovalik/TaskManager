// GetAllUserQueryRequestHandler.cs
using AutoMapper;
using CQRS_Test_Project.Core.Application.Interface.Repository;
using CQRS_Test_Project.Core.Application.Wrappers;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS_Test_Project.Core.Application.Features.Queries.User.GetAllUser
{
    public class GetAllUserQueryRequestHandler : IRequestHandler<GetAllUserQueryRequest, GeneralResponse<List<GetAllUserQueryResponse>>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetAllUserQueryRequestHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<GeneralResponse<List<GetAllUserQueryResponse>>> Handle(GetAllUserQueryRequest request, CancellationToken cancellationToken)
        {
           
            var userEntities = await _userRepository.GetAllAysnc();

            if (userEntities == null || !userEntities.Any())
            {
                return new GeneralResponse<List<GetAllUserQueryResponse>>
                {
                    Data = null,
                    Errors = new List<string> { "Kullanıcılar bulunamadı." },
                    isSuccess = false
                };
            }

           
            var getAllUserQueryResponse = _mapper.Map<List<GetAllUserQueryResponse>>(userEntities);

            return new GeneralResponse<List<GetAllUserQueryResponse>>
            {
                Data = getAllUserQueryResponse,
                Errors = null,
                isSuccess = true
            };
        }
    }
}

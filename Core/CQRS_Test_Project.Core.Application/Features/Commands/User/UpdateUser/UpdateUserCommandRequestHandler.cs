using AutoMapper;
using CQRS_Test_Project.Core.Application.Features.Commands.User.DeleteUser;
using CQRS_Test_Project.Core.Application.Interface.Repository;
using CQRS_Test_Project.Core.Application.Wrappers;
using MediatR;

namespace CQRS_Test_Project.Core.Application.Features.Commands.User.UpdateUser
{
    public class UpdateUserCommandRequestHandler : IRequestHandler<UpdateUserCommandRequest, GeneralResponse<UpdateUserCommandResponse>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public UpdateUserCommandRequestHandler(IUserRepository userRepository, IMediator mediator, IMapper mapper)
        {
            _userRepository = userRepository;
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<GeneralResponse<UpdateUserCommandResponse>> Handle(UpdateUserCommandRequest request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.Id);
            if (user == null)
            {
                return new GeneralResponse<UpdateUserCommandResponse>
                {
                    Data = null,
                    Errors = new List<string> { "Kullanıcı bulunamadı." },
                    isSuccess = false
                };
            }

          
            _mapper.Map(request, user);

            await _userRepository.UpdateAsync(user);

            return new GeneralResponse<UpdateUserCommandResponse>
            {
                Data = new UpdateUserCommandResponse
                {
                    Message = "Kullanıcı başarıyla güncellendi."
                },
                Errors = null,
                isSuccess = true
            };
        }
    }
}

using AutoMapper;
using CQRS_Test_Project.Core.Application.Features.Commands.User.DeleteUser;
using CQRS_Test_Project.Core.Application.Interface.Repository;
using CQRS_Test_Project.Core.Application.Wrappers;
using FluentValidation;
using MediatR;

namespace CQRS_Test_Project.Core.Application.Features.Commands.User.UpdateUser
{
    public class UpdateUserCommandRequestHandler : IRequestHandler<UpdateUserCommandRequest, GeneralResponse<UpdateUserCommandResponse>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IValidator<UpdateUserCommandRequest> _validator;
        private readonly IMapper _mapper;

        public UpdateUserCommandRequestHandler(IUserRepository userRepository,IMapper mapper, IValidator<UpdateUserCommandRequest> validator)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<GeneralResponse<UpdateUserCommandResponse>> Handle(UpdateUserCommandRequest request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                return new GeneralResponse<UpdateUserCommandResponse>
                {
                    Data = null,
                    Errors = new List<string> {"" +validationResult.Errors},
                    isSuccess = false
                };
            }
            
            var user = await _userRepository.GetByIdAsync(request.Id);
            if (user is null)
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

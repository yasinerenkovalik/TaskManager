using AutoMapper;
using CQRS_Test_Project.Core.Application.Wrappers;
using MediatR;
using CQRS_Test_Project.Core.Application.Interface.Repository;

namespace CQRS_Test_Project.Core.Application.Features.Commands.User.DeleteUser
{
    public class DeleteUserCommandRequestHandler : IRequestHandler<DeleteUserCommanRequest, GeneralResponse<DeleteUserCommandResponse>>
    {
        private readonly IUserRepository _userRepository;

        public DeleteUserCommandRequestHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<GeneralResponse<DeleteUserCommandResponse>> Handle(DeleteUserCommanRequest request, CancellationToken cancellationToken)
        {

            var user = await _userRepository.GetByIdAsync(request.UserId);

            if (user == null)
            {
                return new GeneralResponse<DeleteUserCommandResponse>
                {
                    Data = null,
                    Errors = new List<string> { "Kullanıcı bulunamadı." },
                    isSuccess = false
                };
            }

            await _userRepository.DeleteAsync(user.Id);

            return new GeneralResponse<DeleteUserCommandResponse>
            {
                Data = new DeleteUserCommandResponse
                {
                    UserId = user.Id,
                },
                Errors = null,
                isSuccess = true
            };
        }
    }
}

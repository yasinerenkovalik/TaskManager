using AutoMapper;
using CQRS_Test_Project.Core.Application.Interface.Repository;
using CQRS_Test_Project.Core.Domain.Entities;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CQRS_Test_Project.Core.Application.Features.Commands.User.CreateUser
{
    public class CreateUserCommandRequestHandler : IRequestHandler<CreateUserCommandRequest, CreateUserCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IValidator<CreateUserCommandRequest> _validator;
        private readonly ILogger<CreateUserCommandRequestHandler> _logger;
        private readonly IUserRepository _userRepository;
        public CreateUserCommandRequestHandler(IMapper mapper, IValidator<CreateUserCommandRequest> validator, ILogger<CreateUserCommandRequestHandler> logger ,IUserRepository userRepository)
        {
            _mapper = mapper;
            _validator = validator;
            _logger = logger;
            _userRepository = userRepository;
        }

        public async Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {
          
            var validationResult = await _validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
               
                _logger.LogInformation("Doğrulama başarısız. Kullanıcı eklenemedi: {Errors}", string.Join(", ", validationResult.Errors));
                return new CreateUserCommandResponse
                {
                    Id = Guid.Empty, 
                };
            }

       
            var userEntity = _mapper.Map<CQRS_Test_Project.Core.Domain.Entities.User>(request);

       
            await _userRepository.AddAsync(userEntity);

       
            _logger.LogInformation("Yeni kullanıcı başarıyla eklendi: {UserId}", userEntity.BaseID);

      
            return new CreateUserCommandResponse
            {
                Id = userEntity.BaseID
            };
        }
    }
}

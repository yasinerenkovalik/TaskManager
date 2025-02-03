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
            // 1. Gelen request'i doğrula
            var validationResult = await _validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                // Doğrulama başarısızsa hata loglayıp işlemden çıkabiliriz
                _logger.LogInformation("Doğrulama başarısız. Kullanıcı eklenemedi: {Errors}", string.Join(", ", validationResult.Errors));
                return new CreateUserCommandResponse
                {
                    Id = Guid.Empty, // Eklenmediği için boş bir ID döndürüyoruz
                };
            }

            // 2. Request'i Entity'e dönüştür
            var userEntity = _mapper.Map<CQRS_Test_Project.Core.Domain.Entities.User>(request);

            // 3. Repository'i kullanarak kullanıcıyı ekle
            await _userRepository.AddAsync(userEntity);

            // 4. Loglama yap
            _logger.LogInformation("Yeni kullanıcı başarıyla eklendi: {UserId}", userEntity.Id);

            // 5. Response oluştur ve dön
            return new CreateUserCommandResponse
            {
                Id = userEntity.Id
            };
        }
    }
}

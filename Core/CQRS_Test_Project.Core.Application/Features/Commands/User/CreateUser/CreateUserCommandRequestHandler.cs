using AutoMapper;
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
        public CreateUserCommandRequestHandler(IMapper mapper, IValidator<CreateUserCommandRequest> validator, ILogger<CreateUserCommandRequestHandler> logger)
        {
            _mapper = mapper;
            _validator = validator;
            _logger = logger;
        }

        public async Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                _logger.LogInformation("başarıs işlem bla bla bla ...");
                //burda başarısız ise veya başarılı ise ona göre aksiyon alırsın,  general response döneceksen errorları toplama vs. fluent validation kullanımı ile ilgili burası az bakarsın net e 
            }


            return new CreateUserCommandResponse()
            {
                Id = Guid.NewGuid(),
            };
        }
    }
}

using AutoMapper;
using CQRS_Test_Project.Core.Application.Features.Commands.User.CreateUser;
using CQRS_Test_Project.Core.Application.Interface.Repository;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CQRS_Test_Project.Core.Application.Features.Commands.ActivityLog.CreateActivityLog;

public class CreateActivityLogCommandRequestHandler: IRequestHandler<CreateActivityLogCommandRequest, CreateActivityLogCommandResponse>
{
    private readonly IActivityLogRepository _repository;
    private readonly IMapper _mapper;
    private readonly IValidator<CreateActivityLogCommandRequest> _validator;
    private readonly ILogger<CreateActivityLogCommandRequestHandler> _logger;

    public CreateActivityLogCommandRequestHandler(IActivityLogRepository repository, IMapper mapper, IValidator<CreateActivityLogCommandRequest> validator, ILogger<CreateActivityLogCommandRequestHandler> logger)
    {
        _repository = repository;
        _mapper = mapper;
        _validator = validator;
        _logger = logger;
    }

    public async Task<CreateActivityLogCommandResponse> Handle(CreateActivityLogCommandRequest request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request);

        if (!validationResult.IsValid)
        {
               
            _logger.LogInformation("Doğrulama başarısız. Log eklenemedi: {Errors}", string.Join(", ", validationResult.Errors));
            return new CreateActivityLogCommandResponse
            {
                
            };
        }
        
        var activityLog = _mapper.Map<Domain.Entities.ActivityLog>(request);
        activityLog.Activate = true;
        _logger.LogInformation("Yeni Log başarıyla eklendi: ", activityLog.BaseID);
        _repository.AddAsync(activityLog);
        return new CreateActivityLogCommandResponse
        {
            
        };
        
    }
}
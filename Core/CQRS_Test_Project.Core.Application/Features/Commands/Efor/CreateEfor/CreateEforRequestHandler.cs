using AutoMapper;
using CQRS_Test_Project.Core.Application.Features.Commands.ActivityLog.CreateActivityLog;
using CQRS_Test_Project.Core.Application.Interface.Repository;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CQRS_Test_Project.Core.Application.Features.Commands.Efor.CreateEfor;

public class CreateEforRequestHandler:IRequestHandler<CreateEforRequest,CreateEforResponse>
{
    private readonly IEforRepository _repository;
    private readonly IMapper _mapper;
    private readonly IValidator<CreateEforRequest> _validator;
   
    public CreateEforRequestHandler(IEforRepository repository, IMapper mapper, IValidator<CreateEforRequest> validator)
    {
        _repository = repository;
        _mapper = mapper;
        _validator = validator;
    
    }
    public async Task<CreateEforResponse> Handle(CreateEforRequest request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request);

        if (!validationResult.IsValid)
        {
            
            return new CreateEforResponse
            {
                
            };
        }
        
        var activityLog = _mapper.Map<Domain.Entities.Efor>(request);
        activityLog.Activate = true;
        
        _repository.AddAsync(activityLog);
        return new CreateEforResponse
        {
            
        };
    }
}
using AutoMapper;
using CQRS_Test_Project.Core.Application.Interface.Repository;
using CQRS_Test_Project.Core.Application.Wrappers;
using FluentValidation;
using MediatR;

namespace CQRS_Test_Project.Core.Application.Features.Commands.SubTask.CreateSubTag;

public class CreateSubTaskCommandRequestHandler:IRequestHandler<CreateSubTaskCommandRequest, GeneralResponse<CreateSubTaskCommandResponse>>
{
    private readonly ISubTaskRepository _subTaskRepository;
    private readonly IMapper _mapper;
    private readonly IValidator<CreateSubTaskCommandRequest> _validator;

    public CreateSubTaskCommandRequestHandler(ISubTaskRepository subTaskRepository, IMapper mapper, IValidator<CreateSubTaskCommandRequest> validator)
    {
        _subTaskRepository = subTaskRepository;
        _mapper = mapper;
        _validator = validator;
    }

    public async Task<GeneralResponse<CreateSubTaskCommandResponse>> Handle(CreateSubTaskCommandRequest request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request);

        if (!validationResult.IsValid)
        {
            return new GeneralResponse<CreateSubTaskCommandResponse>()
            {
                Errors = new List<string> {""+validationResult.Errors}
            };
        }
        
        var subTask = _mapper.Map<Domain.Entities.SubTask>(request);
        
        await _subTaskRepository.AddAsync(subTask);
        
        return new GeneralResponse<CreateSubTaskCommandResponse>()
        {
            Message = "Success",
        };
        
    }
}
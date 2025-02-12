using AutoMapper;
using CQRS_Test_Project.Core.Application.Interface.Repository;
using CQRS_Test_Project.Core.Application.Wrappers;
using FluentValidation;
using MediatR;

namespace CQRS_Test_Project.Core.Application.Features.Commands.WorkFlow.CreateWorkFlow;

public class CreateWorkFlowCommandRequestHandler:IRequestHandler<CreateWorkFlowCommandRequest, GeneralResponse<CreateWorkFlowCommandResponse>>
{
    private readonly IMapper _mapper;
    private readonly IValidator<CreateWorkFlowCommandRequest> _validator;
    private readonly IWorkflowRepository _workFlowRepository;

    public CreateWorkFlowCommandRequestHandler(IMapper mapper, IValidator<CreateWorkFlowCommandRequest> validator, IWorkflowRepository workFlowRepository)
    {
        _mapper = mapper;
        _validator = validator;
        _workFlowRepository = workFlowRepository;
    }

    public async Task<GeneralResponse<CreateWorkFlowCommandResponse>> Handle(CreateWorkFlowCommandRequest request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request);

        if (!validationResult.IsValid)
        {
            return new GeneralResponse<CreateWorkFlowCommandResponse>()
            {
                Message = validationResult.Errors.ToString()
            };
        }

       
        var workFlow = _mapper.Map<CQRS_Test_Project.Core.Domain.Entities.Workflow>(request);

       
        await _workFlowRepository.AddAsync(workFlow);
        

      
        return new GeneralResponse<CreateWorkFlowCommandResponse>()
        {
            Message = "başarıyla eklendi"
        };
    }
}
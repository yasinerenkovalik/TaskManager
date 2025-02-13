using AutoMapper;
using CQRS_Test_Project.Core.Application.Interface.Repository;
using CQRS_Test_Project.Core.Application.Wrappers;
using FluentValidation;
using MediatR;

namespace CQRS_Test_Project.Core.Application.Features.Commands.WorkFlow.DeleteWorkFlow;

public class DeleteWorkFlowCommandRequestHandler : IRequestHandler<DeleteWorkFlowCommandRequest, GeneralResponse<DeleteWorkFlowCommandResponse>>
{
    private readonly IMapper _mapper;
    private readonly IValidator<DeleteWorkFlowCommandRequest> _validator;
    private readonly IWorkflowRepository _workFlowRepository;

    public DeleteWorkFlowCommandRequestHandler(IMapper mapper, IValidator<DeleteWorkFlowCommandRequest> validator, IWorkflowRepository workFlowRepository)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _validator = validator ?? throw new ArgumentNullException(nameof(validator));
        _workFlowRepository = workFlowRepository ?? throw new ArgumentNullException(nameof(workFlowRepository));
    }

    public async Task<GeneralResponse<DeleteWorkFlowCommandResponse>> Handle(DeleteWorkFlowCommandRequest request, CancellationToken cancellationToken)
    {
        // **1. Adım: Validator ile request doğrula**
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            return new GeneralResponse<DeleteWorkFlowCommandResponse>
            {
                Data = null,
                Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList(),
                isSuccess = false
            };
        }

        // **2. Adım: Workflow var mı kontrol et**
        var workFlow = await _workFlowRepository.GetByIdAsync(request.Id);
        if (workFlow == null)
        {
            return new GeneralResponse<DeleteWorkFlowCommandResponse>
            {
                Data = null,
                Errors = new List<string> { "İş akışı bulunamadı." },
                isSuccess = false
            };
        }

      
        await _workFlowRepository.DeleteAsync(workFlow.BaseID);

        return new GeneralResponse<DeleteWorkFlowCommandResponse>
        {
            Data = new DeleteWorkFlowCommandResponse
            {
                Message = "İş akışı başarıyla silindi.",
            },
            Errors = null,
            isSuccess = true
        };
    }
}

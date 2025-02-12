using AutoMapper;
using CQRS_Test_Project.Core.Application.Features.Commands.WorkFlow.CreateWorkFlow;
using CQRS_Test_Project.Core.Application.Interface.Repository;
using CQRS_Test_Project.Core.Application.Wrappers;
using FluentValidation;
using MediatR;

namespace CQRS_Test_Project.Core.Application.Features.Commands.WorkFlow.UpdateWorkFlow;

public class UpdateWorkFlowCommandRequestHandler:IRequestHandler<UpdateWorkFlowCommandRequest, GeneralResponse<UpdateWorkFlowCommandResponse>>
{
    private readonly IWorkflowRepository _worFlowRepository;
    private readonly IValidator<UpdateWorkFlowCommandRequest> _validator;
    private readonly IMapper _mapper;

    public UpdateWorkFlowCommandRequestHandler(IWorkflowRepository worFlowRepository, IValidator<UpdateWorkFlowCommandRequest> validator, IMapper mapper)
    {
        _worFlowRepository = worFlowRepository;
        _validator = validator;
        _mapper = mapper;
    }

    public async Task<GeneralResponse<UpdateWorkFlowCommandResponse>> Handle(UpdateWorkFlowCommandRequest request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request);

        if (!validationResult.IsValid)
        {
            return new GeneralResponse<UpdateWorkFlowCommandResponse>
            {
                Data = null,
                Errors = new List<string> {"" +validationResult.Errors},
                isSuccess = false
            };
        }
            
        var workflow = await _worFlowRepository.GetByIdAsync(request.Id);
        if (workflow is null)
        {
            return new GeneralResponse<UpdateWorkFlowCommandResponse>
            {
                Data = null,
                Errors = new List<string> { "Kullanıcı bulunamadı." },
                isSuccess = false
            };
        }
            
        _mapper.Map(request, workflow);
        await _worFlowRepository.UpdateAsync(workflow);

        return new GeneralResponse<UpdateWorkFlowCommandResponse>
        {
            Data = new UpdateWorkFlowCommandResponse
            {
                Message = "WorkFlow başarıyla güncellendi."
            },
            Errors = null,
            isSuccess = true
        };
    }
}
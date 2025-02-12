using AutoMapper;
using CQRS_Test_Project.Core.Application.Interface.Repository;
using CQRS_Test_Project.Core.Application.Wrappers;
using FluentValidation;
using MediatR;

namespace CQRS_Test_Project.Core.Application.Features.Commands.WorkFlow.DeleteWorkFlow;

public class DeleteWorkFlowCommandRequestHandler:IRequestHandler<DeleteWorkFlowCommandRequest, GeneralResponse<DeleteWorkFlowCommandResponse>>
{
    private readonly IMapper _mapper;
    private readonly IValidator<DeleteWorkFlowCommandRequest> _validator;
    private readonly IWorkflowRepository _workFlowRepository;

    public async Task<GeneralResponse<DeleteWorkFlowCommandResponse>> Handle(DeleteWorkFlowCommandRequest request, CancellationToken cancellationToken)
    {
        var user = await _workFlowRepository.GetByIdAsync(request.Id);

        if (user == null)
        {
            return new GeneralResponse<DeleteWorkFlowCommandResponse>
            {
                Data = null,
                Errors = new List<string> { "Kullanıcı bulunamadı." },
                isSuccess = false
            };
        }

        await _workFlowRepository.DeleteAsync(user.BaseID);

        return new GeneralResponse<DeleteWorkFlowCommandResponse>
        {
            Data = new DeleteWorkFlowCommandResponse
            {
                Message = "başarıyla silidni",
            },
            Errors = null,
            isSuccess = true
        };
    }
}
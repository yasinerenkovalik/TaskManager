using AutoMapper;
using CQRS_Test_Project.Core.Application.Interface.Repository;
using CQRS_Test_Project.Core.Application.Wrappers;
using FluentValidation;
using MediatR;

namespace CQRS_Test_Project.Core.Application.Features.Commands.SubTask.DeleteSubTag;

public class DeleteSubTaskCommandRequestHandler:IRequestHandler<DeleteSubTaskCommandRequest, GeneralResponse<DeleteSubTaskCommandResponse>>
{
    private readonly ISubTaskRepository _subTaskRepository;
    private readonly IMapper _mapper;
    private readonly IValidator<DeleteSubTaskCommandRequest> _validator;

    public DeleteSubTaskCommandRequestHandler(ISubTaskRepository subTaskRepository, IMapper mapper, IValidator<DeleteSubTaskCommandRequest> validator)
    {
        _subTaskRepository = subTaskRepository;
        _mapper = mapper;
        _validator = validator;
    }

    public async Task<GeneralResponse<DeleteSubTaskCommandResponse>> Handle(DeleteSubTaskCommandRequest request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request);

        if (!validationResult.IsValid)
        {
            return new GeneralResponse<DeleteSubTaskCommandResponse>()
            {
                Errors = new List<string> {""+validationResult.Errors}
            };
        }
        var user = await _subTaskRepository.GetByIdAsync(request.Id);

        if (user == null)
        {
            return new GeneralResponse<DeleteSubTaskCommandResponse>
            {
                Data = null,
                Errors = new List<string> { "Kullanıcı bulunamadı." },
                isSuccess = false
            };
        }

        await _subTaskRepository.DeleteAsync(user.BaseID);

        return new GeneralResponse<DeleteSubTaskCommandResponse>
        {
            Data = new DeleteSubTaskCommandResponse
            {
                UserId = user.BaseID,
            },
            Errors = null,
            isSuccess = true
        };
       
    }
}
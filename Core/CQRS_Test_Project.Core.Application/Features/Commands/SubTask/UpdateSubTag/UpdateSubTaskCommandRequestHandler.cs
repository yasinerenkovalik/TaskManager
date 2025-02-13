using AutoMapper;
using CQRS_Test_Project.Core.Application.Interface.Repository;
using CQRS_Test_Project.Core.Application.Wrappers;
using FluentValidation;
using MediatR;

namespace CQRS_Test_Project.Core.Application.Features.Commands.SubTask.UpdateSubTag;

public class UpdateSubTaskCommandRequestHandler : IRequestHandler<UpdateSubTaskCommandRequest, GeneralResponse<UpdateSubTaskCommandResponse>>
{
    private readonly ISubTaskRepository _subTaskRepository;
    private readonly IMapper _mapper;
    private readonly IValidator<UpdateSubTaskCommandRequest> _validator;

    public UpdateSubTaskCommandRequestHandler(ISubTaskRepository subTaskRepository, IMapper mapper, IValidator<UpdateSubTaskCommandRequest> validator)
    {
        _subTaskRepository = subTaskRepository;
        _mapper = mapper;
        _validator = validator;
    }

    public async Task<GeneralResponse<UpdateSubTaskCommandResponse>> Handle(UpdateSubTaskCommandRequest request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request);

        if (!validationResult.IsValid)
        {
            return new GeneralResponse<UpdateSubTaskCommandResponse>()
            {
                Errors = new List<string> {""+validationResult.Errors}
            };
        }
        var subTask = await _subTaskRepository.GetByIdAsync(request.Id);
        if (subTask is null)
        {
            return new GeneralResponse<UpdateSubTaskCommandResponse>
            {
                Data = null,
                Errors = new List<string> { "Kullanıcı bulunamadı." },
                isSuccess = false
            };
        }
            
        _mapper.Map(request, subTask);
        await _subTaskRepository.UpdateAsync(subTask);

        return new GeneralResponse<UpdateSubTaskCommandResponse>
        {
            Data = new UpdateSubTaskCommandResponse
            {
                Message = "Proje başarıyla güncellendi."
            },
            Errors = null,
            isSuccess = true
        };
    }
}

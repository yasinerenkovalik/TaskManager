using AutoMapper;
using CQRS_Test_Project.Core.Application.Interface.Repository;
using CQRS_Test_Project.Core.Application.Wrappers;
using FluentValidation;
using MediatR;

namespace CQRS_Test_Project.Core.Application.Features.Commands.Task.UpdateTask;

public class UpdateTaskCommandRequestHandler:IRequestHandler<UpdateTaskCommandRequest, GeneralResponse<UpdateTaskCommandResponse>>
{
    private readonly ITaskRepository _taskRepository;
    private readonly IValidator<UpdateTaskCommandRequest> _validator;
    private readonly IMapper _mapper;

    public UpdateTaskCommandRequestHandler(ITaskRepository taskRepository, IValidator<UpdateTaskCommandRequest> validator, IMapper mapper)
    {
        _taskRepository = taskRepository;
        _validator = validator;
        _mapper = mapper;
    }

    public async Task<GeneralResponse<UpdateTaskCommandResponse>> Handle(UpdateTaskCommandRequest request, CancellationToken cancellationToken)
    {
        var task = await _taskRepository.GetByIdAsync(request.Id);

        if (task == null)
        {
            return new GeneralResponse<UpdateTaskCommandResponse>
            {
                Data = null,
                Errors = new List<string> { "Kullanıcı bulunamadı." },
                isSuccess = false
            };
        }
        var user = await _taskRepository.GetByIdAsync(request.Id);
        if (user is null)
        {
            return new GeneralResponse<UpdateTaskCommandResponse>
            {
                Data = null,
                Errors = new List<string> { "Kullanıcı bulunamadı." },
                isSuccess = false
            };
        }
            
        _mapper.Map(request, user);
        await _taskRepository.UpdateAsync(user);

        return new GeneralResponse<UpdateTaskCommandResponse>
        {
            Data = new UpdateTaskCommandResponse
            {
                Message = "Kullanıcı başarıyla güncellendi."
            },
            Errors = null,
            isSuccess = true
        };
        
    }
}
using AutoMapper;
using CQRS_Test_Project.Core.Application.Interface.Repository;
using CQRS_Test_Project.Core.Application.Wrappers;
using FluentValidation;
using MediatR;

namespace CQRS_Test_Project.Core.Application.Features.Commands.Task.DeleteTask;

public class DeleteTaskCommandRequestHandler:IRequestHandler<DeleteTaskCommandRequest, GeneralResponse<DeleteTaskCommandResponse>>
{
    private readonly ITaskRepository _taskRepository;
    private readonly IValidator<DeleteTaskCommandRequest> _validator;
    private readonly IMapper _mapper;

    public DeleteTaskCommandRequestHandler(ITaskRepository taskRepository, IValidator<DeleteTaskCommandRequest> validator, IMapper mapper)
    {
        _taskRepository = taskRepository;
        _validator = validator;
        _mapper = mapper;
    }

    public async Task<GeneralResponse<DeleteTaskCommandResponse>> Handle(DeleteTaskCommandRequest request, CancellationToken cancellationToken)
    {
        var task = await _taskRepository.GetByIdAsync(request.Id);

        if (task == null)
        {
            return new GeneralResponse<DeleteTaskCommandResponse>
            {
                Data = null,
                Errors = new List<string> { "Kullanıcı bulunamadı." },
                isSuccess = false
            };
        }

        await _taskRepository.DeleteAsync(task.BaseID);

        return new GeneralResponse<DeleteTaskCommandResponse>
        {
            Data = new DeleteTaskCommandResponse
            {
                Message = "başarıyla silindi",
            },
            Errors = null,
            isSuccess = true
        };
    }
}
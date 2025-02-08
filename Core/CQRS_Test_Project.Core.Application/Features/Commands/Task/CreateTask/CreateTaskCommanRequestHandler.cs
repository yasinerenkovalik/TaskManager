using AutoMapper;
using CQRS_Test_Project.Core.Application.Interface.Repository;
using CQRS_Test_Project.Core.Application.Wrappers;
using FluentValidation;
using MediatR;

namespace CQRS_Test_Project.Core.Application.Features.Commands.Task.CreateTask;

public class CreateTaskCommanRequestHandler: IRequestHandler<CreateTaskCommanRequest, GeneralResponse<CreateTaskCommanResponse>>
{
    private readonly ITaskRepository _taskRepository;
    private readonly IMapper _mapper;
    private readonly IValidator<CreateTaskCommanRequest> _validator;

    public CreateTaskCommanRequestHandler(ITaskRepository taskRepository, IMapper mapper, IValidator<CreateTaskCommanRequest> validator)
    {
        _taskRepository = taskRepository;
        _mapper = mapper;
        _validator = validator;
    }

    public async Task<GeneralResponse<CreateTaskCommanResponse>> Handle(CreateTaskCommanRequest request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request);

        if (!validationResult.IsValid)
        {
            return new GeneralResponse<CreateTaskCommanResponse>
            {
                Data =
                {
                    Message = "Başarısız Oldu"
                },
                isSuccess = false
            };
        }
        var taskMapper = _mapper.Map<Domain.Entities.Task>(request);
        await _taskRepository.AddAsync(taskMapper);
        return new GeneralResponse<CreateTaskCommanResponse>()
        {
            Data =
            {
                Message = "BAŞARIYLA EKLEND"
            }

        };

    }
}
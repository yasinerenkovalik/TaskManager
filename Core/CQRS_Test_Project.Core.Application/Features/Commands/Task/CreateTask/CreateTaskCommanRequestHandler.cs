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
        _taskRepository = taskRepository ?? throw new ArgumentNullException(nameof(taskRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _validator = validator ?? throw new ArgumentNullException(nameof(validator));
    }

    public async Task<GeneralResponse<CreateTaskCommanResponse>> Handle(CreateTaskCommanRequest request, CancellationToken cancellationToken)
    {
        if (request == null)
            throw new ArgumentNullException(nameof(request), "Request nesnesi null.");

        var validationResult = await _validator.ValidateAsync(request);

        if (!validationResult.IsValid)
        {
            return new GeneralResponse<CreateTaskCommanResponse>
            {
                Data = new CreateTaskCommanResponse
                {
                    Message = "Başarısız Oldu"
                },
                isSuccess = false
            };
        }

        var taskMapper = _mapper.Map<Domain.Entities.Task>(request);
        if (taskMapper == null)
            throw new InvalidOperationException("Task nesnesi eşleştirilemedi.");

        await _taskRepository.AddAsync(taskMapper);

        return new GeneralResponse<CreateTaskCommanResponse>
        {
            Data = new CreateTaskCommanResponse
            {
                Message = "BAŞARIYLA EKLEND"
            }
        };
    }
}

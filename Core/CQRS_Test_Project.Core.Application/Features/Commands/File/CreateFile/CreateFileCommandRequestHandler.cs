using AutoMapper;
using CQRS_Test_Project.Core.Application.Features.Commands.Task.CreateTask;
using CQRS_Test_Project.Core.Application.Interface.Repository;
using CQRS_Test_Project.Core.Domain.Entities;
using CQRS_Test_Project.Core.Application.Wrappers;
using FluentValidation;
using MediatR;

namespace CQRS_Test_Project.Core.Application.Features.Commands.File.CreateFile;

public class CreateFileCommandRequestHandler:IRequestHandler<CreateFileCommandRequest, GeneralResponse<CreateFileCommandResponse>>
{
    private readonly IFileRepository _fileRepository;
    private readonly IMapper _mapper;
    private readonly IValidator<CreateFileCommandRequest> _validator;

    public CreateFileCommandRequestHandler(IFileRepository fileRepository, IMapper mapper, IValidator<CreateFileCommandRequest> validator)
    {
        _fileRepository = fileRepository;
        _mapper = mapper;
        _validator = validator;
    }

    public async Task<GeneralResponse<CreateFileCommandResponse>> Handle(CreateFileCommandRequest request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request);

        if (!validationResult.IsValid)
        {
            return new GeneralResponse<CreateFileCommandResponse>()
            {
                Errors = new List<string> {""+validationResult.Errors}
            };
        }
        var file = _mapper.Map<Domain.Entities.File>(request);
        
        _fileRepository.AddAsync(file);
        
        return new GeneralResponse<CreateFileCommandResponse>()
        {
            Errors = new List<string>{"başarıyla eklendi"}
        };
    }
}
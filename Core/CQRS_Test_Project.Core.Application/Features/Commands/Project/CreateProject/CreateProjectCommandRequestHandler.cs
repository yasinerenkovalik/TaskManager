using AutoMapper;
using CQRS_Test_Project.Core.Application.Features.Commands.File.CreateFile;
using CQRS_Test_Project.Core.Application.Interface.Repository;
using CQRS_Test_Project.Core.Application.Wrappers;
using FluentValidation;
using MediatR;

namespace CQRS_Test_Project.Core.Application.Features.Commands.Project.CreateProject;

public class CreateProjectCommandRequestHandler:IRequestHandler<CreateProjectCommandRequest, GeneralResponse<CreateProjectCommandResponse>>
{
    private readonly IProjectRepository _projectRepository;
    private readonly IMapper _mapper;
    private readonly IValidator<CreateProjectCommandRequest> _validator;

    public CreateProjectCommandRequestHandler(IProjectRepository projectRepository, IMapper mapper, IValidator<CreateProjectCommandRequest> validator)
    {
        _projectRepository = projectRepository;
        _mapper = mapper;
        _validator = validator;
    }
    public async Task<GeneralResponse<CreateProjectCommandResponse>> Handle(CreateProjectCommandRequest request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request);

        if (!validationResult.IsValid)
        {
            return new GeneralResponse<CreateProjectCommandResponse>()
            {
                Errors = new List<string> {""+validationResult.Errors}
            };
        }
        var project = _mapper.Map<Domain.Entities.Project>(request);
        
        await _projectRepository.AddAsync(project);
        
        return new GeneralResponse<CreateProjectCommandResponse>()
        {
            Errors = new List<string> { "başarıyla eklendi" }
        };
    }
}
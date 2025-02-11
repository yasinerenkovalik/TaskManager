using AutoMapper;
using CQRS_Test_Project.Core.Application.Features.Commands.Project.CreateProject;
using CQRS_Test_Project.Core.Application.Interface.Repository;
using CQRS_Test_Project.Core.Application.Wrappers;
using FluentValidation;
using MediatR;

namespace CQRS_Test_Project.Core.Application.Features.Commands.Project.DeleteProject;

public class DeleteProjectCommandRequestHandler: IRequestHandler<DeleteProjectCommandRequest, GeneralResponse<DeleteProjectCommandResponse>>
{
    private readonly IProjectRepository _projectRepository;
    private readonly IMapper _mapper;
    private readonly IValidator<DeleteProjectCommandRequest> _validator;

    public DeleteProjectCommandRequestHandler(IValidator<DeleteProjectCommandRequest> validator, IProjectRepository projectRepository, IMapper mapper)
    {
        _validator = validator;
        _projectRepository = projectRepository;
        _mapper = mapper;
    }

    public async Task<GeneralResponse<DeleteProjectCommandResponse>> Handle(DeleteProjectCommandRequest request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request);

        if (!validationResult.IsValid)
        {
            return new GeneralResponse<DeleteProjectCommandResponse>()
            {
                Errors = new List<string> {""+validationResult.Errors}
            };
        }
       
        _projectRepository.DeleteAsync(request.Id);
        return new GeneralResponse<DeleteProjectCommandResponse>()
        {
            Message = "Project Deleted",
        };
    }
}
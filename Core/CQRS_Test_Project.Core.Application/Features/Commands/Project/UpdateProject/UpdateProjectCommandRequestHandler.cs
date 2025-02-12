using AutoMapper;
using CQRS_Test_Project.Core.Application.Interface.Repository;
using CQRS_Test_Project.Core.Application.Wrappers;
using FluentValidation;
using MediatR;

namespace CQRS_Test_Project.Core.Application.Features.Commands.Project.UpdateProject;

public class UpdateProjectCommandRequestHandler: IRequestHandler<UpdateProjectCommandRequest, GeneralResponse<UpdateProjectCommandResponse>>
{
    private readonly IProjectRepository _projectRepository;
    private readonly IMapper _mapper;
    private readonly IValidator<UpdateProjectCommandRequest> _validator;

    public UpdateProjectCommandRequestHandler(IProjectRepository projectRepository, IMapper mapper, IValidator<UpdateProjectCommandRequest> validator)
    {
        _projectRepository = projectRepository;
        _mapper = mapper;
        _validator = validator;
    }

    public async Task<GeneralResponse<UpdateProjectCommandResponse>> Handle(UpdateProjectCommandRequest request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request);

        if (!validationResult.IsValid)
        {
            return new GeneralResponse<UpdateProjectCommandResponse>()
            {
                Errors = new List<string> {""+validationResult.Errors}
            };
        }
        var user = await _projectRepository.GetByIdAsync(request.Id);
        if (user is null)
        {
            return new GeneralResponse<UpdateProjectCommandResponse>
            {
                Data = null,
                Errors = new List<string> { "Kullanıcı bulunamadı." },
                isSuccess = false
            };
        }
            
        _mapper.Map(request, user);
        await _projectRepository.UpdateAsync(user);

        return new GeneralResponse<UpdateProjectCommandResponse>
        {
            Data = new UpdateProjectCommandResponse
            {
                Message = "Proje başarıyla güncellendi."
            },
            Errors = null,
            isSuccess = true
        };
    }
}
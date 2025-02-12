using AutoMapper;
using CQRS_Test_Project.Core.Application.Interface.Repository;
using CQRS_Test_Project.Core.Application.Wrappers;
using FluentValidation;
using MediatR;

namespace CQRS_Test_Project.Core.Application.Features.Commands.Team.DeleteTeam;

public class DeleteTeamCommandRequestHandler:IRequestHandler<DeleteTeamCommandRequest, GeneralResponse<DeleteTeamCommandResponse>>
{
    private readonly ITeamRepository _taskRepository;
    private readonly IValidator<DeleteTeamCommandRequest> _validator;
    private readonly IMapper _mapper;

    public DeleteTeamCommandRequestHandler(ITeamRepository taskRepository, IValidator<DeleteTeamCommandRequest> validator, IMapper mapper)
    {
        _taskRepository = taskRepository;
        _validator = validator;
        _mapper = mapper;
    }

    public async Task<GeneralResponse<DeleteTeamCommandResponse>> Handle(DeleteTeamCommandRequest request, CancellationToken cancellationToken)
    {
        var team = await _taskRepository.GetByIdAsync(request.Id);

        if (team == null)
        {
            return new GeneralResponse<DeleteTeamCommandResponse>
            {
                Data = null,
                Errors = new List<string> { "Kullanıcı bulunamadı." },
                isSuccess = false
            };
        }

        await _taskRepository.DeleteAsync(team.BaseID);

        return new GeneralResponse<DeleteTeamCommandResponse>
        {
            Data = new DeleteTeamCommandResponse
            {
                Message = "başarıyla silindi",
            },
            Errors = null,
            isSuccess = true
        };
    }
}
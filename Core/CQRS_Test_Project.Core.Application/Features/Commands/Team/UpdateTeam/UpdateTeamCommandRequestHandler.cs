using AutoMapper;
using CQRS_Test_Project.Core.Application.Interface.Repository;
using CQRS_Test_Project.Core.Application.Wrappers;
using FluentValidation;
using MediatR;

namespace CQRS_Test_Project.Core.Application.Features.Commands.Team.UpdateTeam;

public class UpdateTeamCommandRequestHandler : IRequestHandler<UpdateTeamCommandRequest, GeneralResponse<UpdateTeamCommandResponse>>
{
    private readonly ITeamRepository _teamRepository;
    private readonly IValidator<UpdateTeamCommandRequest> _validator;
    private readonly IMapper _mapper;

    public UpdateTeamCommandRequestHandler(ITeamRepository teamRepository, IValidator<UpdateTeamCommandRequest> validator, IMapper mapper)
    {
        _teamRepository = teamRepository ?? throw new ArgumentNullException(nameof(teamRepository));
        _validator = validator ?? throw new ArgumentNullException(nameof(validator));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<GeneralResponse<UpdateTeamCommandResponse>> Handle(UpdateTeamCommandRequest request, CancellationToken cancellationToken)
    {
        // Validation
        var validationResult = await _validator.ValidateAsync(request);
        if (!validationResult.IsValid)
        {
            return new GeneralResponse<UpdateTeamCommandResponse>
            {
                Data = null,
                Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList(),
                isSuccess = false
            };
        }

        // Veritabanından takımı getir
        var team = await _teamRepository.GetByIdAsync(request.Id);
        if (team == null)
        {
            return new GeneralResponse<UpdateTeamCommandResponse>
            {
                Data = null,
                Errors = new List<string> { "Takım bulunamadı." },
                isSuccess = false
            };
        }

        // Mapping işlemi ve güncelleme
        _mapper.Map(request, team);
        await _teamRepository.UpdateAsync(team);

        return new GeneralResponse<UpdateTeamCommandResponse>
        {
            Data = new UpdateTeamCommandResponse
            {
                Message = "Takım başarıyla güncellendi."
            },
            isSuccess = true
        };
    }
}

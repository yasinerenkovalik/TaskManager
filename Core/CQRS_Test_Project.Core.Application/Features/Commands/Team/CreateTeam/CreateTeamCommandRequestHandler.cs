using AutoMapper;
using CQRS_Test_Project.Core.Application.Features.Commands.Task.CreateTask;
using CQRS_Test_Project.Core.Application.Features.Commands.Team.DeleteTeam;
using CQRS_Test_Project.Core.Application.Features.Commands.User.DeleteUser;
using CQRS_Test_Project.Core.Application.Interface.Repository;
using CQRS_Test_Project.Core.Application.Wrappers;
using FluentValidation;
using MediatR;

namespace CQRS_Test_Project.Core.Application.Features.Commands.Team.CreateTeam;

public class CreateTeamCommandRequestHandler : IRequestHandler<CreateTeamCommandRequest, GeneralResponse<CreateTeamCommandResponse>>
{
    private readonly ITeamRepository _teamRepository;
    private readonly IMapper _mapper;
    private readonly IValidator<CreateTeamCommandRequest> _validator;

    public CreateTeamCommandRequestHandler(ITeamRepository teamRepository, IMapper mapper, IValidator<CreateTeamCommandRequest> validator)
    {
        _teamRepository = teamRepository ?? throw new ArgumentNullException(nameof(teamRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _validator = validator ?? throw new ArgumentNullException(nameof(validator));
    }

    public async Task<GeneralResponse<CreateTeamCommandResponse>> Handle(CreateTeamCommandRequest request, CancellationToken cancellationToken)
    {
        if (request == null) 
            throw new ArgumentNullException(nameof(request));

        var validationResult = await _validator.ValidateAsync(request);
        if (!validationResult.IsValid)
        {
            return new GeneralResponse<CreateTeamCommandResponse>
            {
                Data = new CreateTeamCommandResponse { Message = "Başarısız Oldu" },
                isSuccess = false
            };
        }

        var teamMapper = _mapper.Map<Domain.Entities.Team>(request);
        await _teamRepository.AddAsync(teamMapper);

        return new GeneralResponse<CreateTeamCommandResponse>
        {
            Data = new CreateTeamCommandResponse { Message = "BAŞARIYLA EKLENDİ" },
            isSuccess = true
        };
    }
}

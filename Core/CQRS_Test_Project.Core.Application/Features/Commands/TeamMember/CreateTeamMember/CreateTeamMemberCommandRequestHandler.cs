using AutoMapper;
using CQRS_Test_Project.Core.Application.Features.Commands.Team.CreateTeam;
using CQRS_Test_Project.Core.Application.Features.Commands.Team.DeleteTeam;
using CQRS_Test_Project.Core.Application.Interface.Repository;
using CQRS_Test_Project.Core.Application.Wrappers;
using FluentValidation;
using MediatR;

namespace CQRS_Test_Project.Core.Application.Features.Commands.TeamMember.CreateTeamMember;

public class CreateTeamMemberCommandRequestHandler:IRequestHandler<CreateTeamMemberCommandRequest, GeneralResponse<CreateTeamMemberCommandResponse>>
{
    private readonly ITeamMemberRepository _teamMemberRepository;
    private readonly IMapper _mapper;
    private readonly IValidator<CreateTeamMemberCommandRequest> _validator;

    public CreateTeamMemberCommandRequestHandler(ITeamMemberRepository teamMemberRepository, IMapper mapper, IValidator<CreateTeamMemberCommandRequest> validator)
    {
        _teamMemberRepository = teamMemberRepository;
        _mapper = mapper;
        _validator = validator;
    }

    public async Task<GeneralResponse<CreateTeamMemberCommandResponse>> Handle(CreateTeamMemberCommandRequest request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request);

        if (!validationResult.IsValid)
        {
            return new GeneralResponse<CreateTeamMemberCommandResponse>
            {
                Data =
                {
                    Message = "Başarısız Oldu"
                },
                isSuccess = false
            };
        }
        var teamMemberMapper = _mapper.Map<Domain.Entities.TeamMember>(request);
        await _teamMemberRepository.AddAsync(teamMemberMapper);
        return new GeneralResponse<CreateTeamMemberCommandResponse>()
        {
            Data =
            {
                Message = "BAŞARIYLA EKLEND"
            }

        };
    }
}
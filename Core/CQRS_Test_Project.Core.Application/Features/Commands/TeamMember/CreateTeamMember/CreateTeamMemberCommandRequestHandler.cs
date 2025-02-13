using AutoMapper;
using CQRS_Test_Project.Core.Application.Interface.Repository;
using CQRS_Test_Project.Core.Application.Wrappers;
using FluentValidation;
using MediatR;

namespace CQRS_Test_Project.Core.Application.Features.Commands.TeamMember.CreateTeamMember;

public class CreateTeamMemberCommandRequestHandler : IRequestHandler<CreateTeamMemberCommandRequest, GeneralResponse<CreateTeamMemberCommandResponse>>
{
    private readonly ITeamMemberRepository _teamMemberRepository;
    private readonly IMapper _mapper;
    private readonly IValidator<CreateTeamMemberCommandRequest> _validator;

    public CreateTeamMemberCommandRequestHandler(ITeamMemberRepository teamMemberRepository, IMapper mapper, IValidator<CreateTeamMemberCommandRequest> validator)
    {
        _teamMemberRepository = teamMemberRepository ?? throw new ArgumentNullException(nameof(teamMemberRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _validator = validator ?? throw new ArgumentNullException(nameof(validator));
    }

    public async Task<GeneralResponse<CreateTeamMemberCommandResponse>> Handle(CreateTeamMemberCommandRequest request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request);

        if (!validationResult.IsValid)
        {
            return new GeneralResponse<CreateTeamMemberCommandResponse>
            {
                Data = new CreateTeamMemberCommandResponse
                {
                    Message = "Başarısız Oldu"
                },
                isSuccess = false,
                Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList()
            };
        }

        var teamMemberMapper = _mapper.Map<Domain.Entities.TeamMember>(request);
        
        if (teamMemberMapper == null)
        {
            throw new NullReferenceException("Mapper sonucu null döndü. AutoMapper konfigürasyonunu kontrol et.");
        }

        await _teamMemberRepository.AddAsync(teamMemberMapper);

        return new GeneralResponse<CreateTeamMemberCommandResponse>
        {
            Data = new CreateTeamMemberCommandResponse
            {
                Message = "BAŞARIYLA EKLENDİ"
            },
            isSuccess = true
        };
    }
}

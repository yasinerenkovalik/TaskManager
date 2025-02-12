using AutoMapper;
using CQRS_Test_Project.Core.Application.Interface.Repository;
using CQRS_Test_Project.Core.Application.Wrappers;
using FluentValidation;
using MediatR;

namespace CQRS_Test_Project.Core.Application.Features.Commands.TeamMember.UpdateTeamMember;

public class UpdateTeamMemberCommandRequestHandler:IRequestHandler<UpdateTeamMemberCommandRequest, GeneralResponse<UpdateTeamMemberCommandResponse>>
{
    private readonly ITeamMemberRepository _teamMemberRepository;
    private readonly IMapper _mapper;
    private readonly IValidator<UpdateTeamMemberCommandRequest> _validator;

    public UpdateTeamMemberCommandRequestHandler(ITeamMemberRepository teamMemberRepository, IMapper mapper, IValidator<UpdateTeamMemberCommandRequest> validator)
    {
        _teamMemberRepository = teamMemberRepository;
        _mapper = mapper;
        _validator = validator;
    }

    public async Task<GeneralResponse<UpdateTeamMemberCommandResponse>> Handle(UpdateTeamMemberCommandRequest request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request);

        if (!validationResult.IsValid)
        {
            return new GeneralResponse<UpdateTeamMemberCommandResponse>
            {
                Data =
                {
                    Message = "Başarısız Oldu"
                },
                isSuccess = false
            };
        }
        var teamMember = await _teamMemberRepository.GetByIdAsync(request.Id);
        if (teamMember is null)
        {
            return new GeneralResponse<UpdateTeamMemberCommandResponse>
            {
                Data = null,
                Errors = new List<string> { "teamMember bulunamadı." },
                isSuccess = false
            };
        }
            
        _mapper.Map(request, teamMember);
        await _teamMemberRepository.UpdateAsync(teamMember);

        return new GeneralResponse<UpdateTeamMemberCommandResponse>
        {
            Data = new UpdateTeamMemberCommandResponse
            {
                Message = "teamMember başarıyla güncellendi."
            },
            Errors = null,
            isSuccess = true
        };
    }
}
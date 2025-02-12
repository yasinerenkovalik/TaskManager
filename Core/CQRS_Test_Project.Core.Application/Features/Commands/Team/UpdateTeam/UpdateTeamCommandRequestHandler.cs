using AutoMapper;
using CQRS_Test_Project.Core.Application.Interface.Repository;
using CQRS_Test_Project.Core.Application.Wrappers;
using FluentValidation;
using MediatR;

namespace CQRS_Test_Project.Core.Application.Features.Commands.Team.UpdateTeam;

public class UpdateTeamCommandRequestHandler:IRequestHandler<UpdateTeamCommandRequest, GeneralResponse<UpdateTeamCommandResponse>>
{
    private readonly ITeamRepository _teamRepository;
    private readonly IValidator<UpdateTeamCommandRequest> _validator;
    private readonly IMapper _mapper;
    public async Task<GeneralResponse<UpdateTeamCommandResponse>> Handle(UpdateTeamCommandRequest request, CancellationToken cancellationToken)
    {
        var team = await _teamRepository.GetByIdAsync(request.Id);

        if (team == null)
        {
            return new GeneralResponse<UpdateTeamCommandResponse>
            {
                Data = null,
                Errors = new List<string> { "Kullanıcı bulunamadı." },
                isSuccess = false
            };
        }

        var user = await _teamRepository.GetByIdAsync(request.Id);
        if (user is null)
        {
            return new GeneralResponse<UpdateTeamCommandResponse>
            {
                Data = null,
                Errors = new List<string> { "Kullanıcı bulunamadı." },
                isSuccess = false
            };
        }
            
        _mapper.Map(request, user);
        await _teamRepository.UpdateAsync(user);

        return new GeneralResponse<UpdateTeamCommandResponse>
        {
            Data = new UpdateTeamCommandResponse
            {
                Message = "Kullanıcı başarıyla güncellendi."
            },
            Errors = null,
            isSuccess = true
        };
    }
}
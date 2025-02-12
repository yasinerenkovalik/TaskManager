using AutoMapper;
using CQRS_Test_Project.Core.Application.Interface.Repository;
using CQRS_Test_Project.Core.Application.Wrappers;
using FluentValidation;
using MediatR;

namespace CQRS_Test_Project.Core.Application.Features.Commands.TeamMember.DeleteTeamMember;

public class DeleteTeamMemberCommandRequestHandler:IRequestHandler<DeleteTeamMemberCommandRequest, GeneralResponse<DeleteTeamMemberCommandResponse>>
{
    private readonly ITeamMemberRepository _teamMemberRepository;
    private readonly IMapper _mapper;
    private readonly IValidator<DeleteTeamMemberCommandRequest> _validator;

    public DeleteTeamMemberCommandRequestHandler(ITeamMemberRepository teamMemberRepository, IMapper mapper, IValidator<DeleteTeamMemberCommandRequest> validator)
    {
        _teamMemberRepository = teamMemberRepository;
        _mapper = mapper;
        _validator = validator;
    }

    public async Task<GeneralResponse<DeleteTeamMemberCommandResponse>> Handle(DeleteTeamMemberCommandRequest request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request);

        if (!validationResult.IsValid)
        {
            return new GeneralResponse<DeleteTeamMemberCommandResponse>
            {
                Data =
                {
                    Message = "Başarısız Oldu"
                },
                isSuccess = false
            };
        }
        await _teamMemberRepository.DeleteAsync(request.Id);

        return new GeneralResponse<DeleteTeamMemberCommandResponse>
        {
            Data = new DeleteTeamMemberCommandResponse
            {
                Message = "başarıyla silindi",
            },
            Errors = null,
            isSuccess = true
        };
    }
}
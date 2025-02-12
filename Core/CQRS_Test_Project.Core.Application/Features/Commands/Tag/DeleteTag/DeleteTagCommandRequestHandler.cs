using AutoMapper;
using CQRS_Test_Project.Core.Application.Features.Commands.User.DeleteUser;
using CQRS_Test_Project.Core.Application.Interface.Repository;
using CQRS_Test_Project.Core.Application.Wrappers;
using FluentValidation;
using MediatR;

namespace CQRS_Test_Project.Core.Application.Features.Commands.Tag.DeleteTag;

public class DeleteTagCommandRequestHandler:IRequestHandler<DeleteTagCommandRequest, GeneralResponse<DeleteUserCommandResponse>>
{
    private readonly IMapper _mapper;
    private readonly IValidator<DeleteTagCommandRequest> _validator;
    private readonly ITagRepository _userRepository;

    public DeleteTagCommandRequestHandler(IMapper mapper, IValidator<DeleteTagCommandRequest> validator, ITagRepository userRepository)
    {
        _mapper = mapper;
        _validator = validator;
        _userRepository = userRepository;
    }

    public async Task<GeneralResponse<DeleteUserCommandResponse>> Handle(DeleteTagCommandRequest request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request);

        if (!validationResult.IsValid)
        {
            return new GeneralResponse<DeleteUserCommandResponse>
            {
                Message = validationResult.Errors.ToString(), 
            };
        }
        var user = await _userRepository.GetByIdAsync(request.Id);

        if (user == null)
        {
            return new GeneralResponse<DeleteUserCommandResponse>
            {
                Data = null,
                Errors = new List<string> { "Kullanıcı bulunamadı." },
                isSuccess = false
            };
        }

        await _userRepository.DeleteAsync(user.BaseID);

        return new GeneralResponse<DeleteUserCommandResponse>
        {
            Data = new DeleteUserCommandResponse
            {
                UserId = user.BaseID,
            },
            Errors = null,
            isSuccess = true
        };
    }
}
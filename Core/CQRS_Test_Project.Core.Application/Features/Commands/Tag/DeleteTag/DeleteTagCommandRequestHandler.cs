using AutoMapper;
using CQRS_Test_Project.Core.Application.Features.Commands.User.DeleteUser;
using CQRS_Test_Project.Core.Application.Interface.Repository;
using CQRS_Test_Project.Core.Application.Wrappers;
using FluentValidation;
using MediatR;

namespace CQRS_Test_Project.Core.Application.Features.Commands.Tag.DeleteTag;

public class DeleteTagCommandRequestHandler:IRequestHandler<DeleteTagCommandRequest, GeneralResponse<DeleteTagCommandResponse>>
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

    public async Task<GeneralResponse<DeleteTagCommandResponse>> Handle(DeleteTagCommandRequest request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request);

        if (!validationResult.IsValid)
        {
            return new GeneralResponse<DeleteTagCommandResponse>
            {
                Message = validationResult.Errors.ToString(), 
            };
        }
        var tag = await _userRepository.GetByIdAsync(request.Id);

        if (tag == null)
        {
            return new GeneralResponse<DeleteTagCommandResponse>
            {
                Data = null,
                Errors = new List<string> { "Kullanıcı bulunamadı." },
                isSuccess = false
            };
        }

        await _userRepository.DeleteAsync(tag.BaseID);

        return new GeneralResponse<DeleteTagCommandResponse>
        {
            Data = new DeleteTagCommandResponse
            {
                Id = tag.BaseID,
            },
            Errors = null,
            isSuccess = true
        };
    }
}
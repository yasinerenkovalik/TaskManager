using AutoMapper;
using CQRS_Test_Project.Core.Application.Features.Commands.User.UpdateUser;
using CQRS_Test_Project.Core.Application.Interface.Repository;
using CQRS_Test_Project.Core.Application.Wrappers;
using FluentValidation;
using MediatR;

namespace CQRS_Test_Project.Core.Application.Features.Commands.Tag.UpdateTag;

public class UpdateTagCommandRequestHandle:IRequestHandler<UpdateTagCommandRequest,GeneralResponse<UpdateTagCommandResponse>>
{
    private readonly ITagRepository _userRepository;
    private readonly IValidator<UpdateTagCommandRequest> _validator;
    private readonly IMapper _mapper;

    public UpdateTagCommandRequestHandle(ITagRepository userRepository, IValidator<UpdateTagCommandRequest> validator, IMapper mapper)
    {
        _userRepository = userRepository;
        _validator = validator;
        _mapper = mapper;
    }

    public async Task<GeneralResponse<UpdateTagCommandResponse>> Handle(UpdateTagCommandRequest request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request);

        if (!validationResult.IsValid)
        {
            return new GeneralResponse<UpdateTagCommandResponse>
            {
                Data = null,
                Errors = new List<string> {"" +validationResult.Errors},
                isSuccess = false
            };
        }
        var tag = await _userRepository.GetByIdAsync(request.Id);
        if (tag is null)
        {
            return new GeneralResponse<UpdateTagCommandResponse>
            {
                Data = null,
                Errors = new List<string> { "Kullanıcı bulunamadı." },
                isSuccess = false
            };
        }
        _mapper.Map(request, tag);
        await _userRepository.UpdateAsync(tag);

        return new GeneralResponse<UpdateTagCommandResponse>
        {
            Data = new UpdateTagCommandResponse
            {
                Message = "Kullanıcı başarıyla güncellendi."
            },
            Errors = null,
            isSuccess = true
        };
    }
}
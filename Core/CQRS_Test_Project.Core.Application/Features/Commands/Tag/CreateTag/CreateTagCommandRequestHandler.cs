using AutoMapper;
using CQRS_Test_Project.Core.Application.Interface.Repository;
using CQRS_Test_Project.Core.Application.Wrappers;
using FluentValidation;
using MediatR;

namespace CQRS_Test_Project.Core.Application.Features.Commands.Tag.CreateTag;

public class CreateTagCommandRequestHandler:IRequestHandler<CreateTagCommandRequest, GeneralResponse<CreateTagCommandResponse>>
{
    private readonly IMapper _mapper;
    private readonly IValidator<CreateTagCommandRequest> _validator;
    private readonly IUserRepository _userRepository;

    public CreateTagCommandRequestHandler(IMapper mapper, IValidator<CreateTagCommandRequest> validator, IUserRepository userRepository)
    {
        _mapper = mapper;
        _validator = validator;
        _userRepository = userRepository;
    }

    public async Task<GeneralResponse<CreateTagCommandResponse>> Handle(CreateTagCommandRequest request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request);

        if (!validationResult.IsValid)
        {
               
          
            return new  GeneralResponse<CreateTagCommandResponse>()
            {
                Message = validationResult.Errors.ToString()
            };
        }

       
        var userEntity = _mapper.Map<CQRS_Test_Project.Core.Domain.Entities.User>(request);

       
        await _userRepository.AddAsync(userEntity);

        
        return new  GeneralResponse<CreateTagCommandResponse>()
        {
            Message = "Başarıyla eklendi",
        };
    }
}
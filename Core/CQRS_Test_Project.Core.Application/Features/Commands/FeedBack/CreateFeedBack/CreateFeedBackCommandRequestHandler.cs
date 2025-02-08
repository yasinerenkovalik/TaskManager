using AutoMapper;
using CQRS_Test_Project.Core.Application.Interface.Repository;
using CQRS_Test_Project.Core.Application.Wrappers;
using CQRS_Test_Project.Core.Domain.Entities;
using FluentValidation;
using MediatR;

namespace CQRS_Test_Project.Core.Application.Features.Commands.FeedBack.CreateFeedBack;

public class CreateFeedBackCommandRequestHandler:IRequestHandler<CreateFeedBackCommandRequest,GeneralResponse<CreateFeedBackCommandResponse>>
{
    private readonly IMapper _mapper;
    private readonly IFeedBackRepository _feedBackRepository;
    private readonly IValidator<CreateFeedBackCommandRequest> _validator;

    public CreateFeedBackCommandRequestHandler(IMapper mapper, IFeedBackRepository feedBackRepository, IValidator<CreateFeedBackCommandRequest>  validator)
    {
        _mapper = mapper;
        _feedBackRepository = feedBackRepository;
        _validator = validator;
    }

    public async Task<GeneralResponse<CreateFeedBackCommandResponse>> Handle(CreateFeedBackCommandRequest request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request);

        if (!validationResult.IsValid)
        {
            return new GeneralResponse<CreateFeedBackCommandResponse>()
            {
                Errors = new List<string> {""+validationResult.Errors}
            };
        }
        
        var feedBack = _mapper.Map<Feedback>(request);
        
        _feedBackRepository.AddAsync(feedBack);
        
        return new GeneralResponse<CreateFeedBackCommandResponse>()
        {
            Errors = new List<string>{"başarıyla eklendi"}
        };
    }
}
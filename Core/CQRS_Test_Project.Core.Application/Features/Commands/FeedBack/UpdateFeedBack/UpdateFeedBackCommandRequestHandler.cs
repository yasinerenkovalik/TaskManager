using AutoMapper;
using CQRS_Test_Project.Core.Application.Interface.Repository;
using CQRS_Test_Project.Core.Application.Wrappers;
using FluentValidation;
using MediatR;

namespace CQRS_Test_Project.Core.Application.Features.Commands.FeedBack.UpdateFeedBack;

public class UpdateFeedBackCommandRequestHandler:IRequestHandler<UpdateFeedBackCommandRequest,GeneralResponse<UpdateFeedBackCommandResponse>>
{
    private readonly IMapper _mapper;
    private readonly IFeedBackRepository _feedBackRepository;
    private readonly IValidator<UpdateFeedBackCommandRequest> _validator;

    public UpdateFeedBackCommandRequestHandler(IMapper mapper, IFeedBackRepository feedBackRepository, IValidator<UpdateFeedBackCommandRequest> validator)
    {
        _mapper = mapper;
        _feedBackRepository = feedBackRepository;
        _validator = validator;
    }

    public async Task<GeneralResponse<UpdateFeedBackCommandResponse>> Handle(UpdateFeedBackCommandRequest request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request);

        if (!validationResult.IsValid)
        {
            return new GeneralResponse<UpdateFeedBackCommandResponse>()
            {
                Errors = new List<string> {""+validationResult.Errors}
            };
        }
        var updateFeedBackCommandResponse = _feedBackRepository.GetByIdAsync(request.Id);
        if (updateFeedBackCommandResponse is null)
        {
            return new GeneralResponse<UpdateFeedBackCommandResponse>
            {
                Message = "FeedBack Bulunamadı"
            };
        }
        _feedBackRepository.DeleteAsync(request.Id);
        return new GeneralResponse<UpdateFeedBackCommandResponse>
        {
            Message = "FeedBack Başarıyla silindi!",
        };
    }
}
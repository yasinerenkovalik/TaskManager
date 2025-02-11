using AutoMapper;
using CQRS_Test_Project.Core.Application.Interface.Repository;
using CQRS_Test_Project.Core.Application.Wrappers;
using FluentValidation;
using MediatR;

namespace CQRS_Test_Project.Core.Application.Features.Commands.FeedBack.DeleteFeedBack;

public class DeleteFeedBackCommandRequestHandler:IRequestHandler<DeleteFeedBackCommandRequest, GeneralResponse<DeleteFeedBackCommandResponse>>
{
    private readonly IMapper _mapper;
    private readonly IFeedBackRepository _feedBackRepository;
    private readonly IValidator<DeleteFeedBackCommandRequest> _validator;

    public DeleteFeedBackCommandRequestHandler(IMapper mapper, IFeedBackRepository feedBackRepository, IValidator<DeleteFeedBackCommandRequest> validator)
    {
        _mapper = mapper;
        _feedBackRepository = feedBackRepository;
        _validator = validator;
    }

    public async Task<GeneralResponse<DeleteFeedBackCommandResponse>> Handle(DeleteFeedBackCommandRequest request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request);

        if (!validationResult.IsValid)
        {
            return new GeneralResponse<DeleteFeedBackCommandResponse>()
            {
                Errors = new List<string> {""+validationResult.Errors}
            };
        }
        var deleteFeedBackCommandResponse = _feedBackRepository.GetByIdAsync(request.Id);
        if (deleteFeedBackCommandResponse is null)
        {
            return new GeneralResponse<DeleteFeedBackCommandResponse>
            {
                Message = "FeedBack Bulunamadı"
            };
        }
        _feedBackRepository.DeleteAsync(request.Id);
        return new GeneralResponse<DeleteFeedBackCommandResponse>
        {
            Message = "FeedBack Başarıyla silindi!",
        };
        
    }
}
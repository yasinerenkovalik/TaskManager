using CQRS_Test_Project.Core.Application.Wrappers;
using MediatR;

namespace CQRS_Test_Project.Core.Application.Features.Commands.FeedBack.UpdateFeedBack;

public class UpdateFeedBackCommandRequest:IRequest<GeneralResponse<UpdateFeedBackCommandResponse>>
{
    public Guid Id { get; set; }
    public string Message { get; set; }
}
using CQRS_Test_Project.Core.Application.Wrappers;
using MediatR;

namespace CQRS_Test_Project.Core.Application.Features.Commands.FeedBack.CreateFeedBack;

public class CreateFeedBackCommandRequest:IRequest<GeneralResponse<CreateFeedBackCommandResponse>>
{
    public Guid UserId { get; set; }
    public string Message { get; set; }
}
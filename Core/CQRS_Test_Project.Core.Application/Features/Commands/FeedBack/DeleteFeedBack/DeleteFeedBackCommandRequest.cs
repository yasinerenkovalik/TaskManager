using CQRS_Test_Project.Core.Application.Wrappers;
using MediatR;

namespace CQRS_Test_Project.Core.Application.Features.Commands.FeedBack.DeleteFeedBack;

public class DeleteFeedBackCommandRequest:IRequest<GeneralResponse<DeleteFeedBackCommandResponse>>
{
    
    public Guid Id { get; set; }
}
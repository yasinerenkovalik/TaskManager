using CQRS_Test_Project.Core.Application.Wrappers;
using MediatR;
namespace CQRS_Test_Project.Core.Application.Features.Commands.Task.CreateTask;

public class CreateTaskCommanRequest:IRequest<GeneralResponse<CreateTaskCommanResponse>>
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string Priority { get; set; }
    public string Status { get; set; }
    public Guid UserId { get; set; }
}
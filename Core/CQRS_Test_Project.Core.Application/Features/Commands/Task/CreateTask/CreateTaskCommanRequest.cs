using CQRS_Test_Project.Core.Application.Wrappers;
using MediatR;

namespace CQRS_Test_Project.Core.Application.Features.Commands.Task.CreateTask;

public class CreateTaskCommanRequest:IRequest<GeneralResponse<CreateTaskCommanResponse>>
{
    public string Name { get; set; }
}
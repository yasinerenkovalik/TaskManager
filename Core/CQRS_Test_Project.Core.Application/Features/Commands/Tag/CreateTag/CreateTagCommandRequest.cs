using CQRS_Test_Project.Core.Application.Wrappers;
using MediatR;

namespace CQRS_Test_Project.Core.Application.Features.Commands.Tag.CreateTag;

public class CreateTagCommandRequest:IRequest<GeneralResponse<CreateTagCommandResponse>>
{
    public string Name { get; set; }
}
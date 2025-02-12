using CQRS_Test_Project.Core.Application.Wrappers;
using MediatR;

namespace CQRS_Test_Project.Core.Application.Features.Commands.Tag.UpdateTag;

public class UpdateTagCommandRequest:IRequest<GeneralResponse<UpdateTagCommandResponse>>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}
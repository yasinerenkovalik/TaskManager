using CQRS_Test_Project.Core.Application.Features.Commands.User.DeleteUser;
using CQRS_Test_Project.Core.Application.Wrappers;
using MediatR;

namespace CQRS_Test_Project.Core.Application.Features.Commands.Tag.DeleteTag;

public class DeleteTagCommandRequest:IRequest<GeneralResponse<DeleteTagCommandResponse>>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}
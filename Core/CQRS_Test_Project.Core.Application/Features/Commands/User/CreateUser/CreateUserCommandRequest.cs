using MediatR;

namespace CQRS_Test_Project.Core.Application.Features.Commands.User.CreateUser
{
    public class CreateUserCommandRequest : IRequest<CreateUserCommandResponse>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
        public int Age { get; set; }
    }
}

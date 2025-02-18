using MediatR;

namespace CQRS_Test_Project.Core.Application.Features.Commands.User.CreateUser
{
    public class CreateUserCommandRequest(string name, string surname, string email, string role, string passwordHash)
        : IRequest<CreateUserCommandResponse>
    {
        public string Name { get; set; } = name;
        public string Surname { get; set; } = surname;
        public string Email { get; set; } = email;
        public string Role { get; set; } = role;
        public string PasswordHash { get; set; } = passwordHash;
    }
}

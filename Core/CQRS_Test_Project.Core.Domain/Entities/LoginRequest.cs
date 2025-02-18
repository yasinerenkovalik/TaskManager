namespace CQRS_Test_Project.Core.Domain.Entities;

public class LoginRequest
{
    public string Email { get; set; }
    public string Password { get; set; }
}
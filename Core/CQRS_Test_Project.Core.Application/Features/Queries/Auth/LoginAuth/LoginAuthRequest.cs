using CQRS_Test_Project.Core.Application.Wrappers;
using MediatR;

namespace CQRS_Test_Project.Core.Application.Features.Queries.Auth.LoginAuth;

public class LoginAuthRequest:IRequest<GeneralResponse<LoginAuthResponse>>
{
    public string Email { get; set; }
    public string Password { get; set; }
}
using CQRS_Test_Project.Core.Application.Features.Queries.Auth.LoginAuth;

namespace CQRS_Test_Project.Core.Application.Interface.Repository;

public interface IAuthRepository
{
     Task<string?> Login(LoginAuthRequest entity);
}
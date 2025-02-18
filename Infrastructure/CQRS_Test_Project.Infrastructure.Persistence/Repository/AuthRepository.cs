using CQRS_Test_Project.Core.Application.Features.Queries.Auth.LoginAuth;
using CQRS_Test_Project.Core.Application.Interface.Repository;
using CQRS_Test_Project.Core.Domain.Entities;
using CQRS_Test_Project.Infrastructure.Persistence.Context;
using CQRS_Test_Project.Infrastructure.Persistence.Security;
using Microsoft.EntityFrameworkCore;

namespace CQRS_Test_Project.Infrastructure.Persistence.Repository;

public class AuthRepository:IAuthRepository
{
    private readonly CqrsContext _appContext;
    private readonly JwtService _jwtService;

    public AuthRepository(CqrsContext appContext, JwtService jwtService)
    {
        _appContext = appContext;
        _jwtService = jwtService;
    }

    public async Task<string?> Login(LoginAuthRequest entity)
    {
        var user = await _appContext.Users
            .Where(u => u.Email == entity.Email && u.PasswordHash == entity.Password)
            .FirstOrDefaultAsync();
        
        if (user == null)
            return "user not found";
        
        if (user.PasswordHash != entity.Password) 
            return "null";
        
        var token = _jwtService.GenerateToken(user.BaseID.ToString(), user.Role);

        return token;
    }
}
using AutoMapper;
using CQRS_Test_Project.Core.Application.Interface.Repository;
using CQRS_Test_Project.Core.Application.Wrappers;
using MediatR;
using Microsoft.AspNetCore.Identity.Data;

namespace CQRS_Test_Project.Core.Application.Features.Queries.Auth.LoginAuth;

public class LoginAuthRequestHandler : IRequestHandler<LoginAuthRequest, GeneralResponse<LoginAuthResponse>>
{
    private readonly IAuthRepository _repository;

    public LoginAuthRequestHandler(IAuthRepository repository)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }

    public async Task<GeneralResponse<LoginAuthResponse>> Handle(LoginAuthRequest request, CancellationToken cancellationToken)
    {
        if (request == null)
        {
            return new GeneralResponse<LoginAuthResponse>
            {
                Data = null,
                Errors = new List<string> { "Geçersiz istek!" },
                isSuccess = false
            };
        }

        var result = await _repository.Login(request);

        if (string.IsNullOrEmpty(result))
        {
            return new GeneralResponse<LoginAuthResponse>
            {
                Data = null,
                Errors = new List<string> { "Kullanıcı bulunamadı." },
                isSuccess = false
            };
        }

        return new GeneralResponse<LoginAuthResponse>
        {
            Data = new LoginAuthResponse
            {
                Token = result
            },
            Errors = new List<string>(), 
            isSuccess = true
        };
    }
}
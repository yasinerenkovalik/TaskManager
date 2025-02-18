using CQRS_Test_Project.Core.Application.Features.Queries.Auth.LoginAuth;
using CQRS_Test_Project.Core.Domain.Entities;
using CQRS_Test_Project.Infrastructure.Persistence.Security;
using MediatR;
using Microsoft.AspNetCore.Mvc;

[Route("api/auth")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly JwtService _jwtService;
    private readonly IMediator _mediator;

    public AuthController(JwtService jwtService, IMediator mediator)
    {
        _jwtService = jwtService;
        _mediator = mediator;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginAuthRequest request)
    {
        var token = await _mediator.Send(request);
        return Ok(token);
    }
}


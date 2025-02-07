using Microsoft.AspNetCore.Mvc;
using Server.API.Filter;
using Server.Application.Common.Interfaces.Services;
using Server.Contracts.Authentication;
using Server.Domain.Entity.Identity;

namespace Server.API.Controllers;

[ApiController]
[Route("/authentication")]
// [ErrorHandlingFilterAttribute]
public class AuthenticationController : ControllerBase
{
    IAuthenticationService _authenticationService;

    public AuthenticationController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    [HttpPost("login")]
    public IActionResult Login(LoginRequest request)
    {
        var authenticationResult = _authenticationService.Login(request.Email, request.Password);

        var response = new AuthenticationResponse(
            authenticationResult.user.Id,
            authenticationResult.user.FirstName,
            authenticationResult.user.LastName,
            authenticationResult.user.Email,
            authenticationResult.AccessToken
        );

        return Ok(response);
    }

    [HttpPost("register")]
    public IActionResult Register(RegisterRequest request) 
    {
        var user = new AppUsers
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            Password = request.Password
        };

        var authenticationResult = _authenticationService.Register(user);

        var response = new AuthenticationResponse(
            authenticationResult.user.Id,
            authenticationResult.user.FirstName,
            authenticationResult.user.LastName,
            authenticationResult.user.Email,
            authenticationResult.AccessToken
        );

        return Ok(response);
    }
}

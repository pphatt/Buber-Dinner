using Microsoft.AspNetCore.Mvc;
using Server.Application.Common.Interfaces;
using Server.Contracts.Authentication;

namespace Server.API.Controllers;

[ApiController]
[Route("/authentication")]
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
            authenticationResult.Id,
            authenticationResult.FirstName,
            authenticationResult.LastName,
            authenticationResult.Email,
            authenticationResult.AccessToken
        );

        return Ok(response);
    }

    [HttpPost("register")]
    public IActionResult Register(RegisterRequest request) 
    {
        var authenticationResult = _authenticationService.Register(request.FirstName, request.LastName, request.Email, request.Password);

        var response = new AuthenticationResponse(
            authenticationResult.Id,
            authenticationResult.FirstName,
            authenticationResult.LastName,
            authenticationResult.Email,
            authenticationResult.AccessToken
        );

        return Ok(response);
    }
}

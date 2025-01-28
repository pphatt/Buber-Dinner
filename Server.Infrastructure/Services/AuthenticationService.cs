using Server.Application.Common.Interfaces;
using Server.Contracts.Authentication;

namespace Server.Infrastructure.Services;

public class AuthenticationService : IAuthenticationService
{
    public AuthenticationResult Login(string Email, string Password)
    {
        return new AuthenticationResult(Guid.NewGuid(), "FirstName", "LastName", Email, "AccessToken");
    }

    public AuthenticationResult Register(string FirstName, string LastName, string Email, string Password)
    {
        return new AuthenticationResult(Guid.NewGuid(), FirstName, LastName, Email, "AccessToken");
    }
}

using Server.Contracts.Authentication;

namespace Server.Application.Common.Interfaces.Services;

public interface IAuthenticationService
{
    AuthenticationResult Login(string Email, string Password);

    AuthenticationResult Register(string FirstName, string LastName, string Email, string Password);
}

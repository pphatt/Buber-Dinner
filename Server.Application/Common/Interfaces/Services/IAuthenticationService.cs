using Server.Contracts.Authentication;
using Server.Domain.Entity.Identity;

namespace Server.Application.Common.Interfaces.Services;

public interface IAuthenticationService
{
    AuthenticationResult Login(string Email, string Password);

    AuthenticationResult Register(AppUsers user);
}

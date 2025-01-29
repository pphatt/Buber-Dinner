using Server.Application.Common.Interfaces.Authentication;
using Server.Application.Common.Interfaces.Persistence;
using Server.Application.Common.Interfaces.Services;
using Server.Contracts.Authentication;
using Server.Domain.Entity.Identity;

namespace Server.Infrastructure.Services;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public AuthenticationResult Login(string Email, string Password)
    {
        var user = _userRepository.GetUserByEmail(Email);

        if (user is null)
        {
            throw new Exception("User with given email is not exists.");
        }

        if (user.Password != Password)
        {
            throw new Exception("Invalid password.");
        }

        var accessToken = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(user, accessToken);
    }

    public AuthenticationResult Register(AppUsers request)
    {
        var user = _userRepository.GetUserByEmail(request.Email);

        if (user is not null)
        {
            throw new Exception("Email is already taken.");
        }

        var createdUser = new AppUsers 
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            Password = request.Password
        };

        _userRepository.AddUser(createdUser);

        var accessToken = _jwtTokenGenerator.GenerateToken(createdUser);

        return new AuthenticationResult(createdUser, accessToken);
    }
}

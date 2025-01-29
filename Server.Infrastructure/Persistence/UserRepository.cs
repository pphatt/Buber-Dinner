using Server.Application.Common.Interfaces.Persistence;
using Server.Domain.Entity.Identity;

namespace Server.Infrastructure.Persistence;

public class UserRepository : IUserRepository
{
    private static readonly List<AppUsers> _users = new();

    public void AddUser(AppUsers user)
    {
        _users.Add(user);
    }

    public AppUsers? GetUserByEmail(string Email)
    {
        return _users.SingleOrDefault(u => u.Email == Email);
    }
}

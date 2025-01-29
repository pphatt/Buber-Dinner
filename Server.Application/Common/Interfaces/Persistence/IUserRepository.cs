using Server.Domain.Entity.Identity;

namespace Server.Application.Common.Interfaces.Persistence;

public interface IUserRepository
{
    AppUsers? GetUserByEmail(string Email);

    void AddUser(AppUsers user);
}

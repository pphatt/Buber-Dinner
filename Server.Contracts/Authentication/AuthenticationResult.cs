using Server.Domain.Entity.Identity;

namespace Server.Contracts.Authentication;

public record AuthenticationResult(AppUsers user, string AccessToken);

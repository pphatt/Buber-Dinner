﻿namespace Server.Contracts.Authentication;

public record AuthenticationResult(Guid Id, string FirstName, string LastName, string Email, string AccessToken);

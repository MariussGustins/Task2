using Microsoft.AspNetCore.Authorization;

public class HasScopeRequirement : IAuthorizationRequirement
{
    public string[] Scopes { get; }

    public HasScopeRequirement(params string[] scopes)
    {
        Scopes = scopes;
    }
}
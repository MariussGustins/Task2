using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

public class HasScopeHandler : AuthorizationHandler<HasScopeRequirement>
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, HasScopeRequirement requirement)
    {
        // Check if the context has a claim with permissions
        var permissions = context.User.Claims.Where(c => c.Type == "permissions").Select(c => c.Value).ToList();
        
        // Check if any of the required scopes are present in the user's permissions
        if (permissions.Any(p => requirement.Scopes.Contains(p)))
        {
            context.Succeed(requirement);
        }
        
        return Task.CompletedTask;
    }
}
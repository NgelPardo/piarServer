using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace PiarServer.Infrastructure.Authentication;

public class PermissionAuthorizationHandler : AuthorizationHandler<PermissionRequirement>
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionRequirement requirement)
    {

        string? userId = context.User.Claims.FirstOrDefault(
            claim => claim.Type == ClaimTypes.NameIdentifier
        )?.Value;

        if (userId is null)
        {
            return Task.CompletedTask;
        }

        HashSet<string> permissions = context.User.Claims
        .Where(x => x.Type == CustomClaims.Permissions)
        .Select(x => x.Value).ToHashSet();

        if (permissions.Contains(requirement.Permission))
        {
            context.Succeed(requirement);
        }

        return Task.CompletedTask;

    }
}
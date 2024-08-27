using Microsoft.AspNetCore.Authorization;
using PiarServer.Domain.Permissions;

namespace PiarServer.Infrastructure.Authentication;

public class HasPermissionAttribute : AuthorizeAttribute
{

    public HasPermissionAttribute(PermissionEnum permission) : base(policy: permission.ToString())
    {
        
    }

}
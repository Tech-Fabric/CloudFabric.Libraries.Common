using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace CloudFabric.Library.Common.Security
{
    public static class IdentityExtensions
    {
        public static string GetNameIdentifierClaimValue(this ClaimsPrincipal principle)
        {
            return principle.FindFirstValue(BaseClaimTypes.Id);
        }

        public static int GetUserId(this ClaimsPrincipal principal)
        {
            return int.Parse(principal.FindFirstValue("sub"));
        }

        public static string GetClaimValue(this ClaimsPrincipal principal, string type)
        {
            var claims = principal.Claims;
            if (claims == null ||  string.IsNullOrWhiteSpace(type))
            {
                return string.Empty;
            }

            var claim = claims.FirstOrDefault(x => x.Type == type);

            return claim == null ? string.Empty : claim.Value;
            
        }
    }
}

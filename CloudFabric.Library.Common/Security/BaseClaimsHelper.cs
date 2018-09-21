using CloudFabric.Library.Common.Entities;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CloudFabric.Library.Common.Security
{
    public abstract class BaseClaimsHelper<TEntity, TUserRole> where TEntity : BaseUserEntity<TUserRole>
    {
        public async Task<List<Claim>> GetAsync(TEntity user)
        {
            var claims = new List<Claim>();

            int? userId = user?.Id;
            if (userId != null)
            {
                claims.Add(new Claim(ClaimTypes.Id, userId.ToString()));
                claims.Add(new Claim(ClaimTypes.CreatedAt, user.CreatedAt.ToString()));
                claims.Add(new Claim(ClaimTypes.LastUpdatedAt, user.LastUpdatedAt.ToString()));

                var additionalClaims = await GetAdditionalAsync(user);
                claims.AddRange(additionalClaims);
            }
            await Task.CompletedTask;

            return claims;
        }

        public abstract Task<List<Claim>> GetAdditionalAsync(TEntity user);
    }
}

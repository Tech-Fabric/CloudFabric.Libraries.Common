using CloudFabric.Library.Common.Entities;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CloudFabric.Library.Common.Security
{
    public abstract class BaseClaimsHelper<TEntity> where TEntity : BaseUserEntity
    {
        public async Task<List<Claim>> GetAsync(TEntity user)
        {
            var claims = new List<Claim>();

            int? userId = user?.Id;
            if(userId != null)
            {
                claims.Add(new Claim(BaseClaimTypes.Id, userId.ToString()));
                claims.Add(new Claim(BaseClaimTypes.CreatedAt, user.CreatedAt.ToString()));
                claims.Add(new Claim(BaseClaimTypes.LastUpdatedAt, user.LastUpdatedAt.ToString()));

                var additionalClaims = await GetAdditionalAsync(user);
                claims.AddRange(additionalClaims);
            }
            await Task.CompletedTask;

            return claims;
        }

        public abstract Task<List<Claim>> GetAdditionalAsync(TEntity user);
    }
}

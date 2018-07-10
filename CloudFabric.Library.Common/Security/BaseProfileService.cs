using CloudFabric.Library.Common.Entities;
using CloudFabric.Library.Common.HttpClients;
using IdentityModel;
using IdentityServer4.Extensions;
using IdentityServer4.Models;
using IdentityServer4.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudFabric.Library.Common.Security
{
    public class BaseProfileService<THttpClient, TUser, TUserRole> : IProfileService
        where THttpClient : IBaseUserServiceClient<TUser>
        where TUser : BaseUserEntity<TUserRole>
    {
        private THttpClient _client;
        public BaseProfileService(THttpClient client)
        {
            _client = client;
        }

        public Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            context.IssuedClaims = context.Subject.Identities.First().Claims.ToList();
            return Task.CompletedTask;
        }

        public async Task IsActiveAsync(IsActiveContext context)
        {
            context.IsActive = false;

            if (context.Subject == null)
            {
                throw new ArgumentNullException(JwtClaimTypes.Subject);
            }

            var id = context.Subject.GetSubjectId();

            TUser user = null;

            try
            {
                user = await _client.GetById(int.Parse(id));
            }
            catch (Exception ex) { }

            context.IsActive = (bool)user?.IsActive;
        }
    }
}

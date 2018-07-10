using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CloudFabric.Library.Common.Entities;
using CloudFabric.Library.Common.HttpClients;
using IdentityServer4.Models;
using IdentityServer4.Validation;

namespace CloudFabric.Library.Common.Security
{
    public class ResourceOwnerPasswordValidator<THttpClient, TClaimsHelper, TUser, TRole, TUserRole> : IResourceOwnerPasswordValidator 
        where THttpClient : IBaseUserServiceClient<TUser>
        where TClaimsHelper : BaseClaimsHelper<TUser, TUserRole>, new()
        where TUser : BaseUserEntity<TUserRole>
        where TUserRole : BaseUserRoleEntity<TUser, TRole>
    {
        protected THttpClient _client;
        public ResourceOwnerPasswordValidator(THttpClient client)
        {
            _client = client;
        }
        public async Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            var user = await _client.GetByUsernameAndPasswordAsync(context.UserName, context.Password);
            if(user == null)
            {
                context.Result = new GrantValidationResult(TokenRequestErrors.InvalidGrant, "Invalid credentials. Please try again.");
                return;
            }

            var claimsHelper = new TClaimsHelper();
            var claims = await claimsHelper.GetAsync(user);

            context.Result = new GrantValidationResult(user.Id.ToString(), "password", claims);
        }
    }
}

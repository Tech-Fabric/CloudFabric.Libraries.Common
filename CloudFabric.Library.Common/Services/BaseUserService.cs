using CloudFabric.Library.Common.Entities;
using CloudFabric.Library.Common.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CloudFabric.Library.Common.Services
{
    public abstract class BaseUserService<TUser> : BaseService<TUser>, IBaseUserService<TUser> where TUser : BaseEntity
    {
        public BaseUserService(IBaseRepository<TUser> repository) : base(repository)
        {

        }

        public abstract Task<TUser> GetByCredentialsAsync(string primaryCredential, string plainPassword);
    }
}

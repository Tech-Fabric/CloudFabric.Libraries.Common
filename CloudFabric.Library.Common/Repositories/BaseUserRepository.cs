using CloudFabric.Library.Common.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CloudFabric.Library.Common.Repositories
{
    public abstract class BaseUserRepository<TUser, TUserRole> : BaseRepository<TUser>, IBaseUserRepository<TUser, TUserRole> where TUser : BaseUserEntity<TUserRole>
    {
        public BaseUserRepository(DbContext dbContext) : base(dbContext)
        {

        }

        public abstract Task<TUser> GetByCredentialsAsync(string primaryCredential, string hashedPassword);
    }
}

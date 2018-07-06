using CloudFabric.Library.Common.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CloudFabric.Library.Common.Repositories
{
    public interface IBaseUserRepository<TUser, TUserRole> : IBaseRepository<TUser> where TUser: BaseEntity
    {

        Task<TUser> GetByCredentialsAsync(string primaryCredential, string hashedPassword);
    }
}

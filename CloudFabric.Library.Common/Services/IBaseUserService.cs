using CloudFabric.Library.Common.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CloudFabric.Library.Common.Services
{
    public interface IBaseUserService<TUser> : IBaseService<TUser> where TUser : BaseEntity
    {
        /// <summary>
        /// Will get the user with the primary credentials of the system. Usually refering to username & password
        /// </summary>
        /// <param name="primaryCredential">Usually known as username/email.</param>
        /// <param name="plainPassword">Plain text Password</param>
        /// <returns>Returns the user with the given credentials, or null if the username/password is wrong or if the user doesn't exist.</returns>
        Task<TUser> GetByCredentialsAsync(string primaryCredential, string plainPassword);
    }
}

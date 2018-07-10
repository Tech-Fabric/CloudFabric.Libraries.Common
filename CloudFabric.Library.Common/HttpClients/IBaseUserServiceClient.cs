using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CloudFabric.Library.Common.HttpClients
{
    public interface IBaseUserServiceClient<TEntity> where TEntity : class
    {
        Task<TEntity> GetByUsernameAndPasswordAsync(string username, string password);
        Task<TEntity> GetById(int id);
    }
}

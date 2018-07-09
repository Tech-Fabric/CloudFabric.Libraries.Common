using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CloudFabric.Library.Common.HttpClients
{
    public interface IBaseHttpClient<TEntity> where TEntity : class
    {
        Task<TEntity> GetAsync(string uri = "");

        Task<TEntity> PostAsync(string uri, TEntity entity);
        Task<TEntity> PostAsync<TBody>(string uri, TBody body);

        Task<TEntity> PutAsync(string uri, TEntity body);
        Task<TEntity> PutAsync<TBody>(string uri, TBody body);

    }
}

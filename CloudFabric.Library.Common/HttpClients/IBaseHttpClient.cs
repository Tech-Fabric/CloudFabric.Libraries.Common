using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CloudFabric.Library.Common.HttpClients
{
    public interface IBaseHttpClient<TEntity> where TEntity : class
    {
        Task<TEntity> GetAsync(string uri = "");
        Task<T> GetAsync<T>(string uri = "");

        Task<TEntity> PostAsync(string uri, TEntity entity);
        Task<TResponse> PostAsync<TRequest, TResponse>(string uri, TRequest entity);
        Task<TEntity> PostAsync<TBody>(string uri, TBody body);

        Task<TEntity> PutAsync(string uri, TEntity body);
        Task<TResponse> PutAsync<TRequest, TResponse>(string uri, TRequest body);
        Task<TEntity> PutAsync<TBody>(string uri, TBody body);

    }
}

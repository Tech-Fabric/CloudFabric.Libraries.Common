using CloudFabric.Library.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudFabric.Library.Common.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        Task DeleteAsync(int id);
        Task CreateAsync(TEntity entity);
        Task<IQueryable<TEntity>> ListAsync();
        Task<TEntity> GetByIdAsync(int id);
        Task UpdateAsync(int id, TEntity entity);
    }
}

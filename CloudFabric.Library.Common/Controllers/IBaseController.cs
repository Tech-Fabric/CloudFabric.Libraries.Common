using CloudFabric.Library.Common.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CloudFabric.Library.Common.Controllers
{
    public interface IBaseController<TEntity> where TEntity : BaseEntity
    {
        Task<List<TEntity>> ListAsync();
        Task<TEntity> GetByIdAsync(int id);
        Task<TEntity> CreateAsync(TEntity entity);
        Task<TEntity> UpdateAsync(int id, TEntity entity);
        Task<TEntity> DeleteAsync(int id);
    }
}

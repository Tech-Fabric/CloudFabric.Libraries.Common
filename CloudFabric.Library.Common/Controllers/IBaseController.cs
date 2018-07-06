using CloudFabric.Library.Common.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CloudFabric.Library.Common.Controllers
{
    public interface IBaseController<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity> ListAsync();
        Task<List<TEntity>> GetByIdAsync(int id);
        Task<TEntity> Create();
        Task<TEntity> Update();
        Task<TEntity> Delete();
    }
}

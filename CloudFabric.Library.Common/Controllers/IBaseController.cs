using CloudFabric.Library.Common.Entities;
using CloudFabric.Library.Common.Repositories;
using CloudFabric.Library.Common.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CloudFabric.Library.Common.Controllers
{
    public interface IBaseController<TService, TRepository, TDbContext, TEntity> 
        where TService : IBaseService<TRepository, TDbContext, TEntity> 
        where TRepository : IBaseRepository<TDbContext, TEntity>
        where TDbContext : DbContext
        where TEntity : BaseEntity

    {
        Task<List<TEntity>> ListAsync();
        Task<TEntity> GetByIdAsync(int id);
        Task<TEntity> CreateAsync(TEntity entity);
        Task<TEntity> UpdateAsync(int id, TEntity entity);
        Task<TEntity> DeleteAsync(int id);
    }
}

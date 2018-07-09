using CloudFabric.Library.Common.Entities;
using CloudFabric.Library.Common.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudFabric.Library.Common.Services
{
    public interface IBaseService<TRepository, TDbContext, TEntity> 
        where TRepository : IBaseRepository<TDbContext, TEntity>
        where TDbContext : DbContext
        where TEntity : BaseEntity
    {
        Task DeleteAsync(int id);
        Task<TEntity> CreateAsync(TEntity entity);
        Task<IQueryable<TEntity>> ListAsync();
        Task<TEntity> GetByIdAsync(int id);
        Task<TEntity> UpdateAsync(int id, TEntity entity);
    }
}

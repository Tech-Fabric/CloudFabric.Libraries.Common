using CloudFabric.Library.Common.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudFabric.Library.Common.Repositories
{
    public interface IBaseRepository<TDbContext, TEntity> 
        where TEntity : BaseEntity
        where TDbContext : DbContext
    {
        Task DeleteAsync(int id);
        Task CreateAsync(TEntity entity);
        Task<TEntity> GetByIdAsync(int id);
        Task UpdateAsync(int id, TEntity entity);
        IQueryable<TEntity> List();
    }
}

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
    public interface IBaseService<TRepository, TDbContext, TEntity, TModel> 
        where TRepository : IBaseRepository<TDbContext, TEntity>
        where TDbContext : DbContext
        where TEntity : BaseEntity
    {
        Task DeleteAsync(int id);
        Task<TModel> CreateAsync(TModel model);
        Task<List<TModel>> ListAsync();
        Task<TModel> GetByIdAsync(int id);
        Task<TModel> UpdateAsync(int id, TModel model);
    }
}

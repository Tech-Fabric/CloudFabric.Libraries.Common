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
    public interface IBaseController<TService, TRepository, TDbContext, TEntity, TModel> 
        where TService : IBaseService<TRepository, TDbContext, TEntity, TModel> 
        where TRepository : IBaseRepository<TDbContext, TEntity>
        where TDbContext : DbContext
        where TEntity : BaseEntity

    {
        Task<List<TModel>> ListAsync();
        Task<TModel> GetByIdAsync(int id);
        Task<TModel> CreateAsync(TModel model);
        Task<TModel> UpdateAsync(int id, TModel model);
        Task DeleteAsync(int id);
    }
}

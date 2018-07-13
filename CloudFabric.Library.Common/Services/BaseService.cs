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
    public abstract class BaseService<TRepository, TDbContext, TEntity> : IBaseService<TRepository, TDbContext, TEntity> 
        where TRepository : IBaseRepository<TDbContext, TEntity>
        where TDbContext : DbContext
        where TEntity : BaseEntity
    {
        protected TRepository _repository;

        public BaseService(TRepository repository)
        {
            _repository = repository;
        }

        public virtual async Task<TEntity> CreateAsync(TEntity entity)
        {
            await _repository.CreateAsync(entity);
            return entity;
        }

        public virtual async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public virtual async Task<TEntity> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public virtual async Task<IQueryable<TEntity>> ListAsync()
        {
            await Task.CompletedTask;
            return _repository.List();
        }

        public virtual async Task<TEntity> UpdateAsync(int id, TEntity entity)
        {
            await _repository.UpdateAsync(id, entity);
            return entity;
        }
    }
}

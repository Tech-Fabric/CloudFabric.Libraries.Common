using CloudFabric.Library.Common.Entities;
using CloudFabric.Library.Common.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudFabric.Library.Common.Services
{
    public abstract class BaseService<TEntity> : IBaseService<TEntity> where TEntity : BaseEntity
    {
        private IBaseRepository<TEntity> _repository;

        public BaseService(IBaseRepository<TEntity> repository)
        {
            _repository = repository;
        }

        public async Task CreateAsync(TEntity entity)
        {
            await _repository.CreateAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<IQueryable<TEntity>> ListAsync()
        {
            return await _repository.ListAsync();
        }

        public async Task UpdateAsync(int id, TEntity entity)
        {
            await _repository.UpdateAsync(id, entity);
        }
    }
}

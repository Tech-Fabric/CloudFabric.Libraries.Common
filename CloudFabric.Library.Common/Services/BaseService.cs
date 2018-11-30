using AutoMapper;
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
    public abstract class BaseService<TRepository, TDbContext, TEntity, TModel> : IBaseService<TRepository, TDbContext, TEntity, TModel> 
        where TRepository : IBaseRepository<TDbContext, TEntity>
        where TDbContext : DbContext
        where TEntity : BaseEntity
    {
        protected TRepository _repository;
        protected IMapper _mapper;

        public BaseService(TRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public virtual async Task<TModel> CreateAsync(TModel model)
        {
            var entity = _mapper.Map<TModel, TEntity>(model);
            await _repository.CreateAsync(entity);

            return _mapper.Map<TEntity, TModel>(entity);
        }

        public virtual async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public virtual async Task<TModel> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return _mapper.Map<TEntity, TModel>(entity);
        }

        public virtual async Task<List<TModel>> ListAsync()
        {
            await Task.CompletedTask;
            var entities = _repository.List();

            return _mapper.Map<IQueryable<TEntity>, List<TModel>>(entities);
        }

        public virtual async Task<TModel> UpdateAsync(int id, TModel model)
        {
            var entity = _mapper.Map<TModel, TEntity>(model);
            await _repository.UpdateAsync(id, entity);
            return _mapper.Map<TEntity, TModel>(entity);
        }
    }
}

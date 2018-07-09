using CloudFabric.Library.Common.Entities;
using CloudFabric.Library.Common.Repositories;
using CloudFabric.Library.Common.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudFabric.Library.Common.Controllers
{
    public class BaseController<TService, TRepository, TDbContext, TEntity> : IBaseController<TService, TRepository, TDbContext, TEntity> 
        where TService : IBaseService<TRepository, TDbContext, TEntity> 
        where TRepository : IBaseRepository<TDbContext, TEntity>
        where TDbContext : DbContext
        where TEntity : BaseEntity
    {
        public readonly TService _service;

        public BaseController(TService service)
        {
            _service = service;
        }

        [HttpGet("")]
        public async Task<List<TEntity>> ListAsync()
        {
            return (await _service.ListAsync()).ToList();
        }
        
        [HttpGet("{id}")]
        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _service.GetByIdAsync(id);
        }

        [HttpPost("")]
        public async Task<TEntity> CreateAsync([FromBody]TEntity entity)
        {
            await _service.CreateAsync(entity);
            return null;
        }

        [HttpDelete("{id}")]
        public async Task<TEntity> DeleteAsync(int id)
        {
            await _service.DeleteAsync(id);
            return null;
        }

        [HttpPut("{id}")]
        public async Task<TEntity> UpdateAsync(int id, [FromBody]TEntity entity)
        {
            await _service.UpdateAsync(id, entity);
            return null;
        }
    }
}

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
    public class BaseController<TService, TRepository, TDbContext, TEntity, TModel> : IBaseController<TService, TRepository, TDbContext, TEntity, TModel> 
        where TService : IBaseService<TRepository, TDbContext, TEntity, TModel> 
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
        public async Task<List<TModel>> ListAsync()
        {
            return (await _service.ListAsync()).ToList();
        }
        
        [HttpGet("{id}")]
        public async Task<TModel> GetByIdAsync(int id)
        {
            return await _service.GetByIdAsync(id);
        }

        [HttpPost("")]
        public async Task<TModel> CreateAsync([FromBody]TModel model)
        {
            return await _service.CreateAsync(model);
        }

        [HttpDelete("{id}")]
        public async Task DeleteAsync(int id)
        {
            await _service.DeleteAsync(id);
        }

        [HttpPut("{id}")]
        public async Task<TModel> UpdateAsync(int id, [FromBody]TModel model)
        {
            return await _service.UpdateAsync(id, model);
        }
    }
}

using CloudFabric.Library.Common.Entities;
using CloudFabric.Library.Common.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudFabric.Library.Common.Controllers
{
    public class BaseController<TEntity> : IBaseController<TEntity> where TEntity : BaseEntity
    {
        private readonly IBaseService<TEntity> _service;

        public BaseController(IBaseService<TEntity> service)
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

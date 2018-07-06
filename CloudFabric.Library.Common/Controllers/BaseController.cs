using CloudFabric.Library.Common.Entities;
using CloudFabric.Library.Common.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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
        public Task<TEntity> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        [HttpPost("")]
        public Task<TEntity> Create()
        {
            throw new NotImplementedException();
        }

        [HttpDelete("")]
        public Task<TEntity> Delete()
        {
            throw new NotImplementedException();
        }

        [HttpPut("")]
        public Task<TEntity> Update()
        {
            throw new NotImplementedException();
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WarehouseAccounting.DB;
using WarehouseAccounting.Interfaces;
using WarehouseAccounting.Models;
using WarehouseAccounting.Services;

namespace WarehouseAccounting.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResourceOfAdmissionsController : ControllerBase
    {
        private IResourceOfAdmissionsStorage _resourceOfAdmissionsStorage;
        public ResourceOfAdmissionsController(IResourceOfAdmissionsStorage resourceOfAdmissionsStorage)
        {
            _resourceOfAdmissionsStorage = resourceOfAdmissionsStorage;
        }
        [HttpGet("GetById")]
        public async Task<ResourceOfAdmission> GetById(Guid id)
        {
            return await _resourceOfAdmissionsStorage.GetById(id);
        }
        [HttpGet("GetAll")]
        public async Task<List<ResourceOfAdmission>> GetAll()
        {
            return await _resourceOfAdmissionsStorage.GetAll();
        }
        [HttpPut("Create")]
        public async Task<bool> Create(ResourceOfAdmission resourceOfAdmission)
        {
            return await _resourceOfAdmissionsStorage.Create(resourceOfAdmission);
        }
        [HttpDelete("Delete")]
        public async Task<bool> Delete(Guid id)
        {
            return await _resourceOfAdmissionsStorage.Delete(id);
        }

    }
}

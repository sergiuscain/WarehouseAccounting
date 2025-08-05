using Microsoft.AspNetCore.Mvc;
using WarehouseAccounting.Interfaces;
using WarehouseAccounting.Models;

namespace WarehouseAccounting.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResourceController : ControllerBase
    {
        private IResourceStorage _resourceStorage;
        public ResourceController(IResourceStorage resourceStorage)
        {
            _resourceStorage = resourceStorage;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<Resource>>> GetAll()
        {
            return await _resourceStorage.GetAll();
        }

        [HttpGet("GetById")]
        public async Task<ActionResult<Resource>> GetById(Guid id)
        {
            return await _resourceStorage.GetById(id);
        }

        [HttpPost("Create")]
        public async Task<ActionResult<bool>> Create(Resource resource)
        {
            return await _resourceStorage.Create(resource);
        }
        [HttpDelete("Delete")]
        public async Task<ActionResult<bool>> DeleteById(Guid id)
        {
            return await _resourceStorage.DeleteById(id);
        }
        [HttpPut("ChangeStatus")]
        public async Task<ActionResult<bool>> ChangeStatus(Guid id)
        {
            return await _resourceStorage.ChangeStatus(id);
        }
        [HttpGet("GetByStatus")]
        public async Task<ActionResult<List<Resource>>> GetByStatus(bool isActive)
        {
            return await _resourceStorage.GetByStatus(isActive);
        }
        [HttpPut("ChangeNameById")]
        public async Task<ActionResult<bool>> ChangeNameById(Guid id, string newResourceName)
        {
            return await _resourceStorage.ChangeName(id, newResourceName);
        }
    }
}

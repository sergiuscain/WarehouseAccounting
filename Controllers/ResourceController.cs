using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WarehouseAccounting.Models;

namespace WarehouseAccounting.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResourceController : ControllerBase
    {
        private List<Resource> resources = new List<Resource>
        {
           new Resource { Id = 0, IsActive = false, Name = "Null"},
           new Resource { Id = 1, IsActive = true, Name = "ABS филамент"},
           new Resource { Id = 2, IsActive = true, Name = "Хотенд"},
           new Resource { Id = 3, IsActive = true, Name = "PLAA филамент"}

        };

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<Resource>>> GetAll()
        {
            return resources;
        }

        [HttpGet("GetById")]
        public ActionResult<Resource> GetById(int id)
        {
            var result = resources.FirstOrDefault(x => x.Id == id);
            return result == null ? resources.First() : result;
        }
    }
}

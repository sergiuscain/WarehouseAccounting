using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using WarehouseAccounting.DB;
using WarehouseAccounting.Models;

namespace WarehouseAccounting.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResourceController : ControllerBase
    {
        private MyDbContext _context;
        public ResourceController(MyDbContext context)
        {
            _context = context;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<Resource>>> GetAll()
        {
            return await _context.Resources.ToListAsync();
        }

        [HttpGet("GetById")]
        public async Task<ActionResult<Resource>> GetById(Guid id)
        {
            var result = await  _context.Resources.FirstOrDefaultAsync(x => x.Id == id);
            return result == null ? NotFound() : result;
        }

        [HttpPost("CreateResource")]
        public async Task<ActionResult> Create(Resource resource)
        {
            //Первое  бизнес правило - запрещено создавать дублиикаты
            if (await _context.Resources.FirstOrDefaultAsync(r => r.Name == resource.Name || r.Id == resource.Id) == null) 
            {
                _context.Resources.Add(resource);
                await _context.SaveChangesAsync();
                return Ok();
            }
            return BadRequest();
        }
    }
}

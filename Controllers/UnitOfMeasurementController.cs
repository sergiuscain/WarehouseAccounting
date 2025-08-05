using Microsoft.AspNetCore.Mvc;
using WarehouseAccounting.Interfaces;
using WarehouseAccounting.Models;

namespace WarehouseAccounting.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnitOfMeasurementController : ControllerBase
    {
        private IUnitOfMeasurementStorage _unitOfMeasurementStorage;
        public UnitOfMeasurementController(IUnitOfMeasurementStorage unitOfMeasurementStorage)
        {
            _unitOfMeasurementStorage = unitOfMeasurementStorage;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<UnitOfMeasurement>>> GetAll()
        {
            return await _unitOfMeasurementStorage.GetAll();
        }

        [HttpGet("GetById")]
        public async Task<ActionResult<UnitOfMeasurement>> GetById(Guid id)
        {
            return await _unitOfMeasurementStorage.GetById(id);
        }

        [HttpPost("Create")]
        public async Task<ActionResult<bool>> Create(UnitOfMeasurement unitOfMeasurement)
        {
            return await _unitOfMeasurementStorage.Create(unitOfMeasurement);
        }
        [HttpDelete("Delete")]
        public async Task<ActionResult<bool>> DeleteById(Guid id)
        {
            return await _unitOfMeasurementStorage.DeleteById(id);
        }
        [HttpPut("ChangeStatus")]
        public async Task<ActionResult<bool>> ChangeStatus(Guid id)
        {
            return await _unitOfMeasurementStorage.ChangeStatus(id);
        }
        [HttpGet("GetByStatus")]
        public async Task<ActionResult<List<UnitOfMeasurement>>> GetByStatus(bool isActive)
        {
            return await _unitOfMeasurementStorage.GetByStatus(isActive);
        }
        [HttpPut("ChangeNameById")]
        public async Task<ActionResult<bool>> ChangeNameById(Guid id, string newName)
        {
            return await _unitOfMeasurementStorage.ChangeName(id, newName);
        }
    }
}

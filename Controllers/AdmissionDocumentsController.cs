using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WarehouseAccounting.Interfaces;
using WarehouseAccounting.Models;

namespace WarehouseAccounting.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdmissionDocumentsController : ControllerBase
    {
        private IAdmissionDocumentsStorage _admissionDocumentsStorage;
        public AdmissionDocumentsController(IAdmissionDocumentsStorage admissionDocumentsStorage)
        {
            _admissionDocumentsStorage = admissionDocumentsStorage;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<AdmissionDocument>>> GetAll()
        {
            return await _admissionDocumentsStorage.GetAll();
        }

        [HttpGet("GetById")]
        public async Task<ActionResult<AdmissionDocument>> GetById(Guid id)
        {
            return await _admissionDocumentsStorage.GetById(id);
        }

        [HttpPost("Create")]
        public async Task<ActionResult<bool>> Create(AdmissionDocument admissionDocument)
        {
            return await _admissionDocumentsStorage.Create(admissionDocument);
        }
        [HttpDelete("Delete")]
        public async Task<ActionResult<bool>> DeleteById(Guid id)
        {
            return await _admissionDocumentsStorage.DeleteById(id);
        }
    }
}

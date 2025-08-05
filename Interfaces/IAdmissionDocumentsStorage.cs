using WarehouseAccounting.Models;

namespace WarehouseAccounting.Interfaces
{
    public interface IAdmissionDocumentsStorage
    {
        Task<bool> Create(AdmissionDocument admissionDocument);
        Task<bool> DeleteById(Guid admissionDocumentId);
        Task<List<AdmissionDocument>> GetAll();
        Task<AdmissionDocument> GetById(Guid id);
    }
}
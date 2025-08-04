using WarehouseAccounting.Models;

namespace WarehouseAccounting.Interfaces
{
    public interface IUnitOfMeasurementStorage
    {
        Task<bool> ChangeName(Guid unitOfMeasurementId, string name);
        Task<bool> ChangeStatus(Guid unitOfMeasurementId);
        Task<bool> Create(UnitOfMeasurement unitOfMeasurement);
        Task<bool> DeleteById(Guid unitOfMeasurementId);
        Task<List<UnitOfMeasurement>> GetAll();
        Task<UnitOfMeasurement> GetById(Guid id);
        Task<List<UnitOfMeasurement>> GetByStatus(bool isActive);
    }
}
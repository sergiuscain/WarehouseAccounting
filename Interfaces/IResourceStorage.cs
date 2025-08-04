using Microsoft.AspNetCore.Mvc;
using WarehouseAccounting.Models;

namespace WarehouseAccounting.Interfaces
{
    public interface IResourceStorage
    {
        Task<bool> Create(Resource resource);
        Task<bool> DeleteById(Guid id);
        Task<List<Resource>> GetAll();
        Task<Resource> GetById(Guid id);
        Task<bool> ChangeStatus(Guid resourceId);
        Task<List<Resource>> GetResourcesByStatus(bool isActive);
    }
}
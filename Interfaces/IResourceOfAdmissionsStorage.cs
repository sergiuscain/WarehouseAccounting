using Microsoft.AspNetCore.Mvc;
using WarehouseAccounting.Models;

namespace WarehouseAccounting.Interfaces
{
    public interface IResourceOfAdmissionsStorage
    {
        Task<ActionResult<bool>> Create(ResourceOfAdmission resourceOfAdmission);
        Task<bool> Delete(Guid id);
    }
}
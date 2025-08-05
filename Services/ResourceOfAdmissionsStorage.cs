using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WarehouseAccounting.DB;
using WarehouseAccounting.Interfaces;
using WarehouseAccounting.Models;

namespace WarehouseAccounting.Services
{
    public class ResourceOfAdmissionsStorage : IResourceOfAdmissionsStorage
    {
        MyDbContext _context;
        public ResourceOfAdmissionsStorage(MyDbContext context)
        {
            _context = context;
        }
        public async Task<ResourceOfAdmission> GetById(Guid id)
        {
            return await _context.ResourceOfAdmissions.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task GetAll()
        {
            await _context.ResourceOfAdmissions.ToListAsync();
        }
        public async Task<bool> Create(ResourceOfAdmission resourceOfAdmission)
        {
            //Нельзя создать ресурс поступления с таким же Id, который уже существует. 
            if (_context.ResourceOfAdmissions.FirstOrDefault(ra => ra.Id == resourceOfAdmission.Id) == null)
            {
                return false;
            }
            _context.ResourceOfAdmissions.Add(resourceOfAdmission);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> Delete(Guid id)
        {
            var resourceOfAdmissions = await _context.ResourceOfAdmissions.FirstOrDefaultAsync(ra => ra.Id == id);
            //Если ресурс поступления не найден, возвращаем false.
            if (resourceOfAdmissions == null)
            {
                return false;
            }
            await _context.ResourceOfAdmissions.AddAsync(resourceOfAdmissions);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}

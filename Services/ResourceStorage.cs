using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Resources;
using System.Threading.Tasks;
using WarehouseAccounting.DB;
using WarehouseAccounting.Interfaces;
using WarehouseAccounting.Models;

namespace WarehouseAccounting.Services
{
    public class ResourceStorage : IResourceStorage
    {
        private MyDbContext _context;
        public ResourceStorage(MyDbContext context)
        {
            _context = context;
            InitializationResources().Wait();
        }
        /// <summary>
        /// Инициализирует базовые ресурсы, если ресурсы отсутствуют (для теста)
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        private async Task InitializationResources()
        {
            if(_context.Resources.Count() == 0)
            {
                _context.Resources.AddRangeAsync(new List<Resource> {
                    new Resource {Id = Guid.NewGuid(), IsActive = true, Name = "ABS филамент" },
                    new Resource {Id = Guid.NewGuid(), IsActive = true, Name = "PLA филамент" },
                    new Resource {Id = Guid.NewGuid(), IsActive = true, Name = "TPU филамент" },
                    new Resource {Id = Guid.NewGuid(), IsActive = true, Name = "Хотенд" },
                    new Resource {Id = Guid.NewGuid(), IsActive = true, Name = "Набор акриловых красок МалевичЪ" }
                });

                await _context.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Возвращает все ресурсы
        /// </summary>
        /// <returns></returns>
        public async Task<List<Resource>> GetAll()
        {
            return await _context.Resources.ToListAsync();
        }

        /// <summary>
        /// Ищет ресурс по Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Resource> GetById(Guid id)
        {
            return await _context.Resources.FirstOrDefaultAsync(x => x.Id == id);
        }
        /// <summary>
        /// Создает ресурс
        /// </summary>
        /// <param name="resource"></param>
        /// <returns></returns>
        public async Task<bool> Create(Resource resource)
        {
            //Первое  бизнес правило - запрещено создавать дублиикаты
            if (await _context.Resources.FirstOrDefaultAsync(r => r.Name == resource.Name || r.Id == resource.Id) == null)
            {
                _context.Resources.Add(resource);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
        /// <summary>
        /// Удаляет ресурс по Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> DeleteById(Guid resourceId)
        {
            var resource = await GetById(resourceId);
            if (resource != null)
            {
                _context.Resources.Remove(resource);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
        /// <summary>
        /// Меняет статус ресрса на противоположный. Если ресурс активен, делает его НЕ активным и наоборот.
        /// </summary>
        /// <param name="resource"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<bool> ChangeStatus(Guid resourceId)
        {
            var resource = await GetById(resourceId);
            if (resource != null)
            {
                //Меняем статус на противоположный
                resource.IsActive = !resource.IsActive;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
        /// <summary>
        /// Возвращает ресурсы по статусу. false - архивные (не активные)
        /// </summary>
        /// <param name="isActive">Является ли ресурс активным</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<List<Resource>> GetResourcesByStatus(bool isActive)
        {
            return await _context.Resources.Where(r => r.IsActive == isActive).ToListAsync();
        }
        /// <summary>
        /// Переименовывает ресурс
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<bool> ChangeName(Guid resourceId, string name)
        {
            var resource = await GetById(resourceId);
            if (resource != null)
            {
                resource.Name = name;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}

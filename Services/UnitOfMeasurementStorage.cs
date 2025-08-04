using Microsoft.EntityFrameworkCore;
using WarehouseAccounting.DB;
using WarehouseAccounting.Models;

namespace WarehouseAccounting.Services
{
    public class UnitOfMeasurementStorage
    {
        private MyDbContext _context;
        public UnitOfMeasurementStorage(MyDbContext context)
        {
            _context = context;
            InitializationUnitOfMeasurement().Wait();
        }
        /// <summary>
        /// Инициализирует базовые еденицы измерения, если они отсутствуют (для теста)
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        private async Task InitializationUnitOfMeasurement()
        {
            if (_context.Resources.Count() == 0)
            {
                _context.UnitOfMeasurements.AddRangeAsync(new List<UnitOfMeasurement> {
                    new UnitOfMeasurement {Id = Guid.NewGuid(), IsActive = true, Name = "Кг." },
                    new UnitOfMeasurement {Id = Guid.NewGuid(), IsActive = true, Name = "Шт." },
                    new UnitOfMeasurement {Id = Guid.NewGuid(), IsActive = true, Name = "Л." },
                    new UnitOfMeasurement {Id = Guid.NewGuid(), IsActive = true, Name = "Хотенд" },
                    new UnitOfMeasurement {Id = Guid.NewGuid(), IsActive = true, Name = "М." }
                });

                await _context.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Возвращает все единицы измерения
        /// </summary>
        /// <returns></returns>
        public async Task<List<UnitOfMeasurement>> GetAll()
        {
            return await _context.UnitOfMeasurements.ToListAsync();
        }

        /// <summary>
        /// Ищет единицу измерения по Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<UnitOfMeasurement> GetById(Guid id)
        {
            return await _context.UnitOfMeasurements.FirstOrDefaultAsync(x => x.Id == id);
        }
        /// <summary>
        /// Создает еденицу измерения
        /// </summary>
        /// <param name="unitOfMeasurement"></param>
        /// <returns></returns>
        public async Task<bool> Create(UnitOfMeasurement unitOfMeasurement)
        {
            //Первое  бизнес правило - запрещено создавать дублиикаты
            if (await _context.UnitOfMeasurements.FirstOrDefaultAsync(u => u.Name == unitOfMeasurement.Name || u.Id == unitOfMeasurement.Id) == null)
            {
                _context.UnitOfMeasurements.Add(unitOfMeasurement);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
        /// <summary>
        /// Удаляет Единицы измерения по Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> DeleteById(Guid unitOfMeasurementId)
        {
            var unitOfMeasurement = await GetById(unitOfMeasurementId);
            if (unitOfMeasurement != null)
            {
                _context.UnitOfMeasurements.Remove(unitOfMeasurement);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
        /// <summary>
        /// Меняет статус единицы измерения на противоположный. Если она активен, делает её НЕ активной и наоборот.
        /// </summary>
        /// <param name="unitOfMeasurement"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<bool> ChangeStatus(Guid unitOfMeasurementId)
        {
            var unitOfMeasurement = await GetById(unitOfMeasurementId);
            if (unitOfMeasurement != null)
            {
                //Меняем статус на противоположный
                unitOfMeasurement.IsActive = !unitOfMeasurement.IsActive;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
        /// <summary>
        /// Возвращает единицу измерения по статусу. false - архивная (не активная)
        /// </summary>
        /// <param name="isActive">Является ли единица измерения активной</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<List<UnitOfMeasurement>> GetByStatus(bool isActive)
        {
            return await _context.UnitOfMeasurements.Where(u => u.IsActive == isActive).ToListAsync();
        }
        /// <summary>
        /// Переименовывает единицу измерения
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<bool> ChangeName(Guid unitOfMeasurementId, string name)
        {
            var unitOfMeasurement = await GetById(unitOfMeasurementId);
            if (unitOfMeasurement != null)
            {
                unitOfMeasurement.Name = name;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}

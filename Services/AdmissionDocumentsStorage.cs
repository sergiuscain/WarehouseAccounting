using Microsoft.EntityFrameworkCore;
using WarehouseAccounting.DB;
using WarehouseAccounting.Interfaces;
using WarehouseAccounting.Models;

namespace WarehouseAccounting.Services
{
    public class AdmissionDocumentsStorage : IAdmissionDocumentsStorage
    {
        private MyDbContext _context;
        public AdmissionDocumentsStorage(MyDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Возвращает все документы поступления 
        /// </summary>
        /// <returns></returns>
        public async Task<List<AdmissionDocument>> GetAll()
        {
            return await _context.AdmissionDocuments.ToListAsync();
        }

        /// <summary>
        /// Ищет документы поступления по Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<AdmissionDocument> GetById(Guid id)
        {
            return await _context.AdmissionDocuments.FirstOrDefaultAsync(x => x.Id == id);
        }
        /// <summary>
        /// Создает документ поступления 
        /// </summary>
        /// <param name="admissionDocument"></param>
        /// <returns></returns>
        public async Task<bool> Create(AdmissionDocument admissionDocument)
        {
            //Первое  бизнес правило - запрещено создавать дублиикаты
            if (await _context.AdmissionDocuments.FirstOrDefaultAsync(r => r.Number == admissionDocument.Number || r.Id == admissionDocument.Id) == null)
            {
                _context.AdmissionDocuments.Add(admissionDocument);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
        /// <summary>
        /// Удаляет документ поступления по Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> DeleteById(Guid admissionDocumentId)
        {
            var admissionDocument = await GetById(admissionDocumentId);
            if (admissionDocument != null)
            {
                _context.AdmissionDocuments.Remove(admissionDocument);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}

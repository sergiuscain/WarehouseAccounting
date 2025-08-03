using Microsoft.EntityFrameworkCore;
using WarehouseAccounting.Models;

namespace WarehouseAccounting.DB
{
    public class MyDbContext : DbContext
    {
        //Таблицы
        public DbSet<Resource> Resources { get; set; }
        public DbSet<UnitOfMeasurement> UnitOfMeasurements { get; set; }
        public DbSet<AdmissionDocument> AdmissionDocuments { get; set; }
        public DbSet<ResourceOfAdmission> ResourceOfAdmissions { get; set; }

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}

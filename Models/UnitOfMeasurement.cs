namespace WarehouseAccounting.Models
{
    //Единица измерения (идентификатор, наименование, состояние)
    public class UnitOfMeasurement
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
}

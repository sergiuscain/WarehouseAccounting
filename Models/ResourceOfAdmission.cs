namespace WarehouseAccounting.Models
{
    //Ресурс поступления (идентификатор, идентификатор ресурса, идентификатор единицы измерения, количество)
    public class ResourceOfAdmission
    {
        public Guid Id { get; set; }
        public Resource ResourceId { get; set; }
        public UnitOfMeasurement UnitOfMeasurement { get; set; }
        public int Count { get; set; }
        public Guid AdmissionDocumentId { get; set; }
    }
}

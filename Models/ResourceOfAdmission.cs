namespace WarehouseAccounting.Models
{
    //Ресурс поступления (идентификатор, идентификатор документа поступления, идентификатор ресурса, идентификатор единицы измерения, количество)
    public class ResourceOfAdmission
    {
        public Guid Id { get; set; }
        public AdmissionDocument AdmissionDocument { get; set; }
        public Resource Resource { get; set; }
        public UnitOfMeasurement UnitOfMeasurement { get; set; }
        public int Count { get; set; }
    }
}

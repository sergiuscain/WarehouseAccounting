namespace WarehouseAccounting.Models
{
    //Документ поступления (идентификатор, номер, дата)
    public class AdmissionDocument
    {
        public Guid Id { get; set; }
        public int Number { get; set; }
        public DateTime Date { get; set; }
    }
}

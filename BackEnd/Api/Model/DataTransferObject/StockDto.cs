namespace Api.Model.DataTransferObject
{
    public class StockDto
    {
        public long Id { get; set; } = long.MinValue;
        public long MaterialId { get; set; } = long.MinValue;
        public long SupplierId { get; set; } = long.MinValue;
        public int Qtty { get; set; } = int.MinValue;
        public int OldQtty { get; set; } = int.MinValue;
        public int NewQtty { get; set; } = int.MinValue;
        public String MaterialName { get; set; } = String.Empty;
        public String SupplierName { get; set; } = String.Empty;
        public String Movimentation { get; set; } = String.Empty;
        public DateTime CreatedDate { get; set; } = DateTime.MinValue;
        public DateTime LastUpdatedDate { get; set; } = DateTime.MinValue;
        public int Status { get; set; } = int.MinValue;
    }
}

namespace Api.Model.DataTransferObject
{
    public class MaterialsDto
    {
        public long Id { get; set; } = long.MinValue;
        public String Name { get; set; } = String.Empty;
        public String Code { get; set; } = String.Empty;
        public DateTime DueDate { get; set; } = DateTime.MinValue;
        public DateTime CreatedDate { get; set; } = DateTime.MinValue;
        public DateTime LastUpdatedDate { get; set; } = DateTime.MinValue;
        public DateTime CanceledDate { get; set; } = DateTime.MinValue;
        public int Status { get; set; } = int.MinValue;
    }
}

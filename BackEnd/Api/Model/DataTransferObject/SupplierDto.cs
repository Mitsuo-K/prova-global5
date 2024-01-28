using System.Numerics;

namespace Api.Model.Dto
{
    public class SupplierDto
    {
        public long Id { get; set; } = long.MinValue;
        public String Name { get; set; } = String.Empty;
        public String Email { get; set; } = String.Empty;
        public String DDD { get; set; } = String.Empty;
        public String Phone { get; set; } = String.Empty;
        public DateTime CreatedDate { get; set; } = DateTime.MinValue;
        public DateTime LastUpdatedDate { get; set; } = DateTime.MinValue;
        public DateTime CanceledDate { get; set; } = DateTime.MinValue;
        public int Status { get; set; } = int.MinValue;
    }
}

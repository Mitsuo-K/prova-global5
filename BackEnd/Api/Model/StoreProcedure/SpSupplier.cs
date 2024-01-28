using System.Numerics;
using Api.Model.StoreProcedure;

namespace Api.Model.StoreProcedure
{
    public class SpSupplier : StoredProcedureBaseModel
    {
        [SqlParameter(false)]
        public string SPName = "sp_supplier";
        [SqlParameter(true)]
        public int Action { get; set; } = int.MinValue;
        [SqlParameter(true)]
        public long Id { get; set; } = long.MinValue;
        [SqlParameter(true)]
        public String Name { get; set; } = String.Empty; 
        [SqlParameter(true)]
        public String Email { get; set; } = String.Empty;
        [SqlParameter(true)]
        public String DDD { get; set; } = String.Empty;
        [SqlParameter(true)]
        public String Phone { get; set; } = String.Empty;
        [SqlParameter(true)]
        public int Status { get; set; } = int.MinValue;
    }
}

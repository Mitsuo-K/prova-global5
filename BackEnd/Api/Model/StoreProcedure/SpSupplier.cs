using System.Numerics;

namespace Api.Model.StoreProcedures
{
    public class SpSupplier : StoredProcedureBaseModel
    {
        [SqlParameter(false)]
        public string SPName = "sp_supplier";
        [SqlParameter(true)]
        public int Action { get; set; } = int.MinValue;
        [SqlParameter(true)]
        public long Id { get; set; } = long.MinValue;
    }
}

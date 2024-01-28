namespace Api.Model.StoreProcedure
{
    public class SpStock : StoredProcedureBaseModel
    {
        [SqlParameter(false)]
        public string SPName = "sp_stock";
        [SqlParameter(true)]
        public int Action { get; set; } = int.MinValue;
        [SqlParameter(true)]
        public long Id { get; set; } = long.MinValue;
        [SqlParameter(true)]
        public long MaterialId { get; set; } = long.MinValue;
        [SqlParameter(true)]
        public long SupplierId { get; set; } = long.MinValue;
        [SqlParameter(true)]
        public int Qtty { get; set; } = int.MinValue;

        [SqlParameter(true)]
        public int Status { get; set; } = int.MinValue;
    }
}


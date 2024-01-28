namespace Api.Model.StoreProcedure
{
    public class SpMaterials : StoredProcedureBaseModel
    {
        [SqlParameter(false)]
        public string SPName = "sp_Materials";
        [SqlParameter(true)]
        public int Action { get; set; } = int.MinValue;
        [SqlParameter(true)]
        public long Id { get; set; } = long.MinValue;
        [SqlParameter(true)]
        public String Name { get; set; } = String.Empty;
        [SqlParameter(true)]
        public String Code { get; set; } = String.Empty;
        [SqlParameter(true)]
        public DateTime DueDate{ get; set; } = DateTime.MinValue;
        [SqlParameter(true)]
        public int Status { get; set; } = int.MinValue;
    }
}

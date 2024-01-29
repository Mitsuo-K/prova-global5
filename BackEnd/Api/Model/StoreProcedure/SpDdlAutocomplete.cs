namespace Api.Model.StoreProcedure
{
    public class SpDdlAutocomplete : StoredProcedureBaseModel
    {
        [SqlParameter(false)]
        public string SPName = "sp_ddlAutocomplete";
        [SqlParameter(true)]
        public int Action { get; set; } = int.MinValue;
    }
}

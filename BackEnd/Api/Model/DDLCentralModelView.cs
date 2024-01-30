using Api.Model.DataTransferObject;
using Api.Model.StoreProcedure;
using System.Data;

namespace Api.Model
{
    public class DDLCentralModelView
    {
        private readonly ConnManager connManager;
        public DDLCentralModelView(ConnManager conn)
        {
            connManager = conn;
        }

        private List<dynamic>? ExecuteMultiReturnOperation(int action)
        {
            try
            {
                SpDdlAutocomplete sp = DtoToSP(action);
                DataSet ds = connManager.GetDataSetFromAdapter(sp.returnStoredProcedureString(sp.SPName), sp.ReturnParameterList());

                return Utils.DataSetToExpandoList(ds);
            }
            catch (Exception e)
            {
                // Log the exception
                Console.WriteLine(e);
                return null;
            }
        }

        public List<dynamic>? GetSupplierList() => ExecuteMultiReturnOperation(1);

        public List<dynamic>? GetMaterialsList() => ExecuteMultiReturnOperation(2);

        private SpDdlAutocomplete DtoToSP(int Action)
        {
            return new SpDdlAutocomplete()
            {
                Action = Utils.TreatInt(Action)
            };
        }
    }
}

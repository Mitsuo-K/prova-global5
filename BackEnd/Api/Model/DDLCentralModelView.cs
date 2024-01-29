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

        public List<dynamic> GetSupplierList()
        {
            try
            {
                SpDdlAutocomplete sp = DtoToSP(1);
                DataSet ds = connManager.GetDataSetFromAdapter(sp.returnStoredProcedureString(sp.SPName), sp.ReturnParameterList());

                return Utils.DataSetToExpandoList(ds);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public List<dynamic> GetMaterialsList()
        {
            try
            {
                SpDdlAutocomplete sp = DtoToSP(2);
                DataSet ds = connManager.GetDataSetFromAdapter(sp.returnStoredProcedureString(sp.SPName), sp.ReturnParameterList());

                return Utils.DataSetToExpandoList(ds);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        private SpDdlAutocomplete DtoToSP(int Action)
        {
            return new SpDdlAutocomplete()
            {
                Action = Utils.TreatInt(Action)
            };
        }
    }
}

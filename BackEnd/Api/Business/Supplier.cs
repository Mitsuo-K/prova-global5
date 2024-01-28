using Api.Model.Dto;
using Api.Model.StoreProcedures;
using System.Data;

namespace Api.Business
{
    public class Supplier
    {
        private readonly ConnManager connManager;
        public Supplier(ConnManager conn)
        {
            connManager = conn;
        }

        public SupplierDto? Authenticate(SupplierDto dto)
        {
            try
            {
                SpSupplier sp = DtoToSP(dto, 1);
                DataSet ds = connManager.GetDataSetFromAdapter(sp.returnStoredProcedureString(sp.SPName), sp.ReturnParameterList());

                return !Utils.IsNull(ds) && ds.Tables[0].Rows.Count > 0 ? DRtoDTO(ds.Tables[0].Rows[0]) : null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }


        private SpSupplier DtoToSP(SupplierDto dto, int Action)
        {
            return new SpSupplier()
            {
                Action = Utils.TreatInt(Action),
                Id = Utils.Treatlong(dto.Id),
            };
        }

        private SupplierDto DRtoDTO(DataRow row)
        {
            return new SupplierDto()
            {
                Id = Utils.DRToBigInt(row, "Id"),
            };
        }
    }
}

using Api.Model.DataTransferObject;
using Api.Model.StoreProcedure;
using System.Data;

namespace Api.Model
{
    public class SupplierModelView
    {
        private readonly ConnManager connManager;
        public SupplierModelView(ConnManager conn)
        {
            connManager = conn;
        }

        public SupplierDto? InsertSupplier(SupplierDto dto)
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

        public SupplierDto? UpdateSupplier(SupplierDto dto)
        {
            try
            {
                SpSupplier sp = DtoToSP(dto, 2);
                DataSet ds = connManager.GetDataSetFromAdapter(sp.returnStoredProcedureString(sp.SPName), sp.ReturnParameterList());

                return !Utils.IsNull(ds) && ds.Tables[0].Rows.Count > 0 ? DRtoDTO(ds.Tables[0].Rows[0]) : null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public List<SupplierDto>? GetSupplier(SupplierDto dto)
        {
            try
            {
                SpSupplier sp = DtoToSP(dto, 3);
                DataSet ds = connManager.GetDataSetFromAdapter(sp.returnStoredProcedureString(sp.SPName), sp.ReturnParameterList());

                return !Utils.IsNull(ds) && ds.Tables[0].Rows.Count > 0 ? DStoDTOList(ds, 0) : null;
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
                Name = Utils.TreatString(dto.Name),
                Email = Utils.TreatString(dto.Email),
                DDD = Utils.TreatString(dto.DDD),
                Phone = Utils.TreatString(dto.Phone),
                Status = Utils.TreatStatus(dto.Status),
            };
        }

        private List<SupplierDto> DStoDTOList(DataSet ds, int TableIndex)
        {
            List<SupplierDto> itens = new List<SupplierDto>();
            foreach (DataRow row in ds.Tables[TableIndex].Rows)
            {
                itens.Add(DRtoDTO(row));
            }
            return itens;
        }

        private SupplierDto DRtoDTO(DataRow row)
        {
            return new SupplierDto()
            {
                Id = Utils.DRToBigInt(row, "Id"),
                Name = Utils.DRToString(row, "Name"),
                Email = Utils.DRToString(row, "Email"),
                DDD = Utils.DRToString(row, "DDD"),
                Phone = Utils.DRToString(row, "PhoneNumber"),
                CreatedDate = Utils.DRToDateTime(row, "CreatedDate"),
                LastUpdatedDate = Utils.DRToDateTime(row, "LastUpdatedDate"),
                CanceledDate = Utils.DRToDateTime(row, "CanceledDate"),
                Status = Utils.DRToInt(row, "Status"),
            };
        }
    }
}

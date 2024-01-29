using Api.Model.DataTransferObject;
using Api.Model.StoreProcedure;
using System.Data;

namespace Api.Model
{
    public class MaterialsModelView
    {
        private readonly ConnManager connManager;
        public MaterialsModelView(ConnManager conn)
        {
            connManager = conn;
        }

        public MaterialsDto? InsertMaterial(MaterialsDto dto)
        {
            try
            {
                SpMaterials sp = DtoToSP(dto, 1);
                DataSet ds = connManager.GetDataSetFromAdapter(sp.returnStoredProcedureString(sp.SPName), sp.ReturnParameterList());

                return !Utils.IsNull(ds) && ds.Tables[0].Rows.Count > 0 ? DRtoDTO(ds.Tables[0].Rows[0]) : null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public MaterialsDto? UpdateMaterial(MaterialsDto dto)
        {
            try
            {
                SpMaterials sp = DtoToSP(dto, 2);
                DataSet ds = connManager.GetDataSetFromAdapter(sp.returnStoredProcedureString(sp.SPName), sp.ReturnParameterList());

                return !Utils.IsNull(ds) && ds.Tables[0].Rows.Count > 0 ? DRtoDTO(ds.Tables[0].Rows[0]) : null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public List<MaterialsDto>? GetMaterials(MaterialsDto dto)
        {
            try
            {
                SpMaterials sp = DtoToSP(dto, 3);
                DataSet ds = connManager.GetDataSetFromAdapter(sp.returnStoredProcedureString(sp.SPName), sp.ReturnParameterList());

                return !Utils.IsNull(ds) && ds.Tables[0].Rows.Count > 0 ? DStoDTOList(ds, 0) : null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        private SpMaterials DtoToSP(MaterialsDto dto, int Action)
        {
            return new SpMaterials()
            {
                Action = Utils.TreatInt(Action),
                Id = Utils.Treatlong(dto.Id),
                Name = Utils.TreatString(dto.Name),
                Code = Utils.TreatString(dto.Code),
                DueDate = Utils.TreatDateTime(dto.DueDate),
                Status = Utils.TreatStatus(dto.Status),
            };
        }

        private List<MaterialsDto> DStoDTOList(DataSet ds, int TableIndex)
        {
            List<MaterialsDto> itens = new List<MaterialsDto>();
            foreach (DataRow row in ds.Tables[TableIndex].Rows)
            {
                itens.Add(DRtoDTO(row));
            }
            return itens;
        }

        private MaterialsDto DRtoDTO(DataRow row)
        {
            return new MaterialsDto()
            {
                Id = Utils.DRToBigInt(row, "Id"),
                Name = Utils.DRToString(row, "Name"),
                Code = Utils.DRToString(row, "Code"),
                DueDate = Utils.DRToDateTime(row, "DueDate"),
                CreatedDate = Utils.DRToDateTime(row, "CreatedDate"),
                LastUpdatedDate = Utils.DRToDateTime(row, "LastUpdatedDate"),
                CanceledDate = Utils.DRToDateTime(row, "CanceledDate"),
                Status = Utils.DRToInt(row, "Status"),
            };
        }
    }
}

using Api.Model.DataTransferObject;
using Api.Model.StoreProcedure;
using System.Data;

namespace Api.Model
{
    public class StockModelView
    {
        private readonly ConnManager connManager;
        public StockModelView(ConnManager conn)
        {
            connManager = conn;
        }
        public StockDto? InsertStock(StockDto dto)
        {
            try
            {
                SpStock sp = DtoToSP(dto, 1);
                DataSet ds = connManager.GetDataSetFromAdapter(sp.returnStoredProcedureString(sp.SPName), sp.ReturnParameterList());

                return !Utils.IsNull(ds) && ds.Tables[0].Rows.Count > 0 ? DRtoDTO(ds.Tables[0].Rows[0]) : null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public StockDto? UpdateStock(StockDto dto)
        {
            try
            {
                SpStock sp = DtoToSP(dto, 2);
                DataSet ds = connManager.GetDataSetFromAdapter(sp.returnStoredProcedureString(sp.SPName), sp.ReturnParameterList());

                return !Utils.IsNull(ds) && ds.Tables[0].Rows.Count > 0 ? DRtoDTO(ds.Tables[0].Rows[0]) : null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public List<StockDto>? GetStock(StockDto dto)
        {
            try
            {
                SpStock sp = DtoToSP(dto, 3);
                DataSet ds = connManager.GetDataSetFromAdapter(sp.returnStoredProcedureString(sp.SPName), sp.ReturnParameterList());

                return !Utils.IsNull(ds) && ds.Tables[0].Rows.Count > 0 ? DStoDTOList(ds, 0) : null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public List<StockDto>? GetStockHist(StockDto dto)
        {
            try
            {
                SpStock sp = DtoToSP(dto, 4);
                DataSet ds = connManager.GetDataSetFromAdapter(sp.returnStoredProcedureString(sp.SPName), sp.ReturnParameterList());

                return !Utils.IsNull(ds) && ds.Tables[0].Rows.Count > 0 ? DStoDTOList(ds, 0) : null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        private SpStock DtoToSP(StockDto dto, int Action)
        {
            return new SpStock()
            {
                Action = Utils.TreatInt(Action),
                Id = Utils.Treatlong(dto.Id),
                MaterialId = Utils.Treatlong(dto.MaterialId),
                SupplierId = Utils.Treatlong(dto.SupplierId),
                Qtty = Utils.TreatIntNoMinValue(dto.Qtty),
                Status = Utils.TreatStatus(dto.Status),
            };
        }

        private List<StockDto> DStoDTOList(DataSet ds, int TableIndex)
        {
            List<StockDto> itens = new List<StockDto>();
            foreach (DataRow row in ds.Tables[TableIndex].Rows)
            {
                itens.Add(DRtoDTO(row));
            }
            return itens;
        }

        private StockDto DRtoDTO(DataRow row)
        {
            return new StockDto()
            {
                Id = Utils.DRToBigInt(row, "Id"),
                MaterialId = Utils.DRToBigInt(row, "MaterialId"),
                SupplierId = Utils.DRToBigInt(row, "SupplierId"),
                Qtty = Utils.DRToInt(row, "Qtty"),
                OldQtty = Utils.DRToInt(row, "OldQtty"),
                NewQtty = Utils.DRToInt(row, "NewQtty"),
                MaterialName = Utils.DRToString(row, "Materials"),
                SupplierName = Utils.DRToString(row, "Supplier"),
                Movimentation = Utils.DRToString(row, "Movimentation"),
                CreatedDate = Utils.DRToDateTime(row, "CreatedDate"),
                LastUpdatedDate = Utils.DRToDateTime(row, "LastUpdatedDate"),
                Status = Utils.DRToInt(row, "Status"),
            };
        }
    }
}

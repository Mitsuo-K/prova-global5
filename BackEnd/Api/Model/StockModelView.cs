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
        private StockDto? ExecuteSingleReturnOperation(StockDto dto, int action)
        {
            try
            {
                SpStock sp = DtoToSP(dto, action);
                DataSet ds = connManager.GetDataSetFromAdapter(sp.returnStoredProcedureString(sp.SPName), sp.ReturnParameterList());

                return !Utils.IsNull(ds) && ds.Tables[0].Rows.Count > 0 ? DRtoDTO(ds.Tables[0].Rows[0]) : null;
            }
            catch (Exception e)
            {
                // Log the exception
                Console.WriteLine(e);
                return null;
            }
        }

        private List<StockDto>? ExecuteMultiReturnOperation(StockDto dto, int action)
        {
            try
            {
                SpStock sp = DtoToSP(dto, action);
                DataSet ds = connManager.GetDataSetFromAdapter(sp.returnStoredProcedureString(sp.SPName), sp.ReturnParameterList());

                return !Utils.IsNull(ds) && ds.Tables[0].Rows.Count > 0 ? DStoDTOList(ds,0) : null;
            }
            catch (Exception e)
            {
                // Log the exception
                Console.WriteLine(e);
                return null;
            }
        }

        public StockDto? InsertStock(StockDto dto) => ExecuteSingleReturnOperation(dto, 1);

        public StockDto? UpdateStock(StockDto dto) => ExecuteSingleReturnOperation(dto, 2);

        public List<StockDto>? GetStock(StockDto dto) => ExecuteMultiReturnOperation(dto, 3);

        public List<StockDto>? GetStockHist(StockDto dto) => ExecuteMultiReturnOperation(dto, 4);

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

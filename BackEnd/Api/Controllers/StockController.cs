using Api.Model.DataTransferObject;
using Api.Model;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StockController : ControllerBase
    {
        StockModelView stock;

        public StockController(StockModelView stock)
        {
            this.stock = stock;
        }

        [HttpPost("InsertStock")]
        public IActionResult InsertStock(StockDto dto)
        {
            var result = stock.InsertStock(dto);
            return !Utils.IsNull(result) ? Ok(result) : NotFound();
        }
        [HttpPut("UpdateStock")]
        public IActionResult UpdateStock(StockDto dto)
        {
            var result = stock.UpdateStock(dto);
            return !Utils.IsNull(result) ? Ok(result) : NotFound();
        }
        [HttpPost("GetStock")]
        public IActionResult GetStock(StockDto dto)
        {
            var result = stock.GetStock(dto);
            return !Utils.IsNull(result) ? Ok(result) : NotFound();
        }

        [HttpPost("GetStockHist")]
        public IActionResult GetStockHist(StockDto dto)
        {
            var result = stock.GetStockHist(dto);
            return !Utils.IsNull(result) ? Ok(result) : NotFound();
        }
    }
}

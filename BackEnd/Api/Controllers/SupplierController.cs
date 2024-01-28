using Api.Model.DataTransferObject;
using Microsoft.AspNetCore.Mvc;
using Api.Model;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SupllierController : ControllerBase
    {
        SupplierModelView supplier;

        public SupllierController(SupplierModelView supplier)
        {
            this.supplier = supplier;
        }

        [HttpPut("InsertSupplier")]
        public IActionResult InsertSupplier(SupplierDto dto)
        {
            var result = supplier.InsertSupplier(dto);
            return !Utils.IsNull(result) ? Ok(result) : NotFound();
        }
        [HttpPut("UpdateSupplier")]
        public IActionResult UpdateSupplier(SupplierDto dto)
        {
            var result = supplier.UpdateSupplier(dto);
            return !Utils.IsNull(result) ? Ok(result) : NotFound();
        }
        [HttpPost("GetSupplier")]
        public IActionResult GetSupplier(SupplierDto dto)
        {
            var result = supplier.GetSupplier(dto);
            return !Utils.IsNull(result) ? Ok(result) : NotFound();
        }
    }
}

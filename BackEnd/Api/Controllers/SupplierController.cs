using Api.Model.DataTransferObject;
using Microsoft.AspNetCore.Mvc;
using Api.Model;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SupplierController : ControllerBase
    {
        private readonly SupplierModelView supplier;

        public SupplierController(SupplierModelView supplier)
        {
            this.supplier = supplier;
        }

        [HttpPost("InsertSupplier")]
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

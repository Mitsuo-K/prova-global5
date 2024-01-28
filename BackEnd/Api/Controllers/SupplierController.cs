using Api.Model.Dto;
using Api.Business;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SupllierController : ControllerBase
    {
        Supplier supplier;

        public SupllierController(Supplier supplier)
        {
            this.supplier = supplier;
        }

        [HttpPut("InsertSupplier")]
        public IActionResult Authenticate(SupplierDto dto)
        {
            var result = supplier.Authenticate(dto);
            return !Utils.IsNull(result) ? Ok(result) : NotFound();
        }
    }
}

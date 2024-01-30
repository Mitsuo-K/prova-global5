using Api.Model;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DDLCentralController : ControllerBase
    {
        private readonly DDLCentralModelView ddlCentral;

        public DDLCentralController(DDLCentralModelView ddlCentral)
        {
            this.ddlCentral = ddlCentral;
        }

        [HttpGet("GetSupplierList")]
        public IActionResult GetSupplierList()
        {
            var result = ddlCentral.GetSupplierList();
            return !Utils.IsNull(result) ? Ok(result) : NotFound();
        }

        [HttpGet("GetMaterialsList")]
        public IActionResult GetMaterialsList()
        {
            var result = ddlCentral.GetMaterialsList();
            return !Utils.IsNull(result) ? Ok(result) : NotFound();
        }
    }
}

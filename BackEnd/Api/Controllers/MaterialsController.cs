using Api.Model;
using Api.Model.DataTransferObject;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MaterialsController : ControllerBase
    {
        MaterialsModelView materials;

        public MaterialsController(MaterialsModelView materials)
        {
            this.materials = materials;
        }

        [HttpPost("InsertMaterial")]
        public IActionResult InsertMaterial(MaterialsDto dto)
        {
            var result = materials.InsertMaterial(dto);
            return !Utils.IsNull(result) ? Ok(result) : NotFound();
        }
        [HttpPut("UpdateMaterial")]
        public IActionResult UpdateMaterial(MaterialsDto dto)
        {
            var result = materials.UpdateMaterial(dto);
            return !Utils.IsNull(result) ? Ok(result) : NotFound();
        }
        [HttpPost("GetMaterials")]
        public IActionResult GetMaterials(MaterialsDto dto)
        {
            var result = materials.GetMaterials(dto);
            return !Utils.IsNull(result) ? Ok(result) : NotFound();
        }
    }
}

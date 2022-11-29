using Microsoft.AspNetCore.Mvc;
using InspectionAPI.Models;
using InspectionAPI.Interfaces;

namespace InspectionAPI.Controllers {
  [Route("api/[controller]")]
  [ApiController]
  public class InspectionTypesController : ControllerBase {
    private readonly IInspectionTypesService _inspectionTypesService;

    public InspectionTypesController(IInspectionTypesService inspectionTypesService) {
      _inspectionTypesService = inspectionTypesService;
    }

    // GET: api/InspectionTypes
    [HttpGet]
    public async Task<IEnumerable<InspectionType>> GetInspectionTypes() {
      return await _inspectionTypesService.GetInspectionTypes();
    }

    // GET: api/InspectionTypes/5
    [HttpGet("{id}")]
    public async Task<ActionResult<InspectionType>> GetInspectionType(int id) {
      var inspectionType = await _inspectionTypesService.GetInspectionType(id);

      if (inspectionType == null) {
        return NotFound();
      }

      return inspectionType;
    }

    // PUT: api/InspectionTypes/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutInspectionType(int id, InspectionType inspectionType) {

      var result = await _inspectionTypesService.PutInspectionType(id, inspectionType);

      if (result == false) {
        return NotFound();
      }

      return NoContent();
    }

    // POST: api/InspectionTypes
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<InspectionType>> PostInspectionType(InspectionType inspectionType) {
      var inspectionTyp = await _inspectionTypesService.PostInspectionType(inspectionType);

      return CreatedAtAction("GetInspectionType", new { id = inspectionTyp.Id }, inspectionTyp);
    }

    // DELETE: api/InspectionTypes/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteInspectionType(int id) {
      var inspectionType = await _inspectionTypesService.DeleteInspectionType(id);
      if (inspectionType == false) {
        return NotFound();
      }

      return NoContent();
    }
  }
}

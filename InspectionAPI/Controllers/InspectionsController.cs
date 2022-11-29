using Microsoft.AspNetCore.Mvc;
using InspectionAPI.Models;
using InspectionAPI.Interfaces;

namespace InspectionAPI.Controllers {
  [Route("api/[controller]")]
  [ApiController]
  public class InspectionsController : ControllerBase {
    private readonly IInspectionsService _inspectionsService;

    public InspectionsController(IInspectionsService inspectionTypesService) {
      _inspectionsService = inspectionTypesService;
    }

    // GET: api/Inspections
    [HttpGet]
    public async Task<IEnumerable<Inspection>> GetInspections() {
      return await _inspectionsService.GetInspections();
    }

    // GET: api/Inspections/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Inspection>> GetInspection(int id) {
      var inspection = await _inspectionsService.GetInspection(id);

      if (inspection == null) {
        return NotFound();
      }

      return inspection;
    }

    // PUT: api/Inspections/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutInspection(int id, Inspection inspection) {

      var result = await _inspectionsService.PutInspection(id, inspection);

      if (result == false) {
        return NotFound();
      }

      return NoContent();
    }

    // POST: api/Inspections
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Inspection>> PostInspection(Inspection inspection) {
      var inspectionn = await _inspectionsService.PostInspection(inspection);

      return CreatedAtAction("GetInspection", new { id = inspectionn.Id }, inspectionn);
    }

    // DELETE: api/Inspections/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteInspection(int id) {
      var inspectionType = await _inspectionsService.DeleteInspection(id);
      if (inspectionType == false) {
        return NotFound();
      }

      return NoContent();
    }
  }
}

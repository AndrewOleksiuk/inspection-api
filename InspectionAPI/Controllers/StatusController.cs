using Microsoft.AspNetCore.Mvc;
using InspectionAPI.Models;
using InspectionAPI.Interfaces;

namespace InspectionAPI.Controllers {
  [Route("api/[controller]")]
  [ApiController]
  public class StatusController : ControllerBase {
    private readonly IStatusService _statusService;

    public StatusController(IStatusService statusService) {
      _statusService = statusService;
    }

    // GET: api/Status
    [HttpGet]
    public async Task<IEnumerable<Status>> GetStatuses() {
      return await _statusService.GetStatuses();
    }

    // GET: api/Inspections/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Status>> GetStatus(int id) {
      var status = await _statusService.GetStatus(id);

      if (status == null) {
        return NotFound();
      }

      return status;
    }

    // PUT: api/Status/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutStatus(int id, Status status) {

      var result = await _statusService.PutStatus(id, status);

      if (result == false) {
        return NotFound();
      }

      return NoContent();
    }

    // POST: api/Statuss
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Status>> PostStatus(Status status) {
      var statuss = await _statusService.PostStatus(status);

      return CreatedAtAction("GetStatus", new { id = statuss.Id }, statuss);
    }

    // DELETE: api/Status/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteStatus(int id) {
      var status = await _statusService.DeleteStatus(id);
      if (status == false) {
        return NotFound();
      }

      return NoContent();
    }
  }
}

using InspectionAPI.Data;
using InspectionAPI.Interfaces;
using InspectionAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace InspectionAPI.Services {
  public class StatusService: IStatusService {

    private readonly DataContext _context;

    public StatusService(DataContext context) {
      this._context = context;
    }

    public async Task<IEnumerable<Status>> GetStatuses() {
      return await _context.Statuses.ToListAsync();
    }

    public async Task<Status> GetStatus(int id) {
      return await _context.Statuses.FindAsync(id);
    }

    public async Task<bool> PutStatus(int id, Status status) {
      if (id != status.Id) {
        return false;
      }

      _context.Entry(status).State = EntityState.Modified;

      try {
        await _context.SaveChangesAsync();
      } catch (DbUpdateConcurrencyException) {
        if (!StatusExists(id)) {
          return false;
        } else {
          throw;
        }
      }

      return true;
    }

    public async Task<Status> PostStatus(Status status) {
      _context.Statuses.Add(status);
      await _context.SaveChangesAsync();

      return status;
    }

    public async Task<bool> DeleteStatus(int id) {
      var status = await _context.Statuses.FindAsync(id);
      if (status == null) {
        return false;
      }

      _context.Statuses.Remove(status);
      await _context.SaveChangesAsync();

      return true;
    }

    private bool StatusExists(int id) {
      return _context.Statuses.Any(e => e.Id == id);
    }
  }
}

using InspectionAPI.Data;
using InspectionAPI.Interfaces;
using InspectionAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace InspectionAPI.Services {
  public class InspectionsService: IInspectionsService {

    private readonly DataContext _context;

    public InspectionsService(DataContext context) {
      _context = context;
    }

    public async Task<IEnumerable<Inspection>> GetInspections() {
      return await _context.Inspections.ToListAsync();
    }

    public async Task<Inspection> GetInspection(int id) {
      return await _context.Inspections.FindAsync(id);

    }

    public async Task<bool> PutInspection(int id, Inspection inspection) {
      if (id != inspection.Id) {
        return false;
      }

      _context.Entry(inspection).State = EntityState.Modified;

      try {
        await _context.SaveChangesAsync();
      } catch (DbUpdateConcurrencyException) {
        if (!InspectionExists(id)) {
          return false;
        } else {
          throw;
        }
      }

      return true;
    }

    public async Task<Inspection> PostInspection(Inspection inspection) {
      _context.Inspections.Add(inspection);
      await _context.SaveChangesAsync();

      return inspection;
    }

    public async Task<bool> DeleteInspection(int id) {
      var inspection = await _context.Inspections.FindAsync(id);
      if (inspection == null) {
        return false;
      }

      _context.Inspections.Remove(inspection);
      await _context.SaveChangesAsync();

      return true;
    }

    private bool InspectionExists(int id) {
      return _context.Inspections.Any(e => e.Id == id);
    }
  }
}

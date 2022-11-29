using InspectionAPI.Data;
using InspectionAPI.Interfaces;
using InspectionAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace InspectionAPI.Services {
  public class InspectionTypesService: IInspectionTypesService {

    private readonly DataContext _context;

    public InspectionTypesService(DataContext context) {
      this._context = context;  
    }

    public async Task<IEnumerable<InspectionType>> GetInspectionTypes() {
      return await _context.InspectionTypes.ToListAsync();
    }

    public async Task<InspectionType> GetInspectionType(int id) {
      return await _context.InspectionTypes.FindAsync(id);

    }

    public async Task<bool> PutInspectionType(int id, InspectionType inspectionType) {
      if (id != inspectionType.Id) {
        return false;
      }

      _context.Entry(inspectionType).State = EntityState.Modified;

      try {
        await _context.SaveChangesAsync();
      } catch (DbUpdateConcurrencyException) {
        if (!InspectionTypeExists(id)) {
          return false;
        } else {
          throw;
        }
      }

      return true;
    }

    public async Task<InspectionType> PostInspectionType(InspectionType inspectionType) {
      _context.InspectionTypes.Add(inspectionType);
      await _context.SaveChangesAsync();

      return inspectionType;
    }

    public async Task<bool> DeleteInspectionType(int id) {
      var inspectionType = await _context.InspectionTypes.FindAsync(id);
      if (inspectionType == null) {
        return false;
      }

      _context.InspectionTypes.Remove(inspectionType);
      await _context.SaveChangesAsync();

      return true;
    }

    private bool InspectionTypeExists(int id) {
      return _context.InspectionTypes.Any(e => e.Id == id);
    }
  }
}

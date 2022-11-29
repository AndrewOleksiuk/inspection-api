using InspectionAPI.Models;

namespace InspectionAPI.Interfaces {
  public interface IInspectionsService {
    Task<IEnumerable<Inspection>> GetInspections();

    Task<Inspection> GetInspection(int id);

    Task<bool> PutInspection(int id, Inspection inspection);

    Task<Inspection> PostInspection(Inspection inspection);

    Task<bool> DeleteInspection(int id);
  }
}

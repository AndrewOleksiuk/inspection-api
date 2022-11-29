using InspectionAPI.Models;

namespace InspectionAPI.Interfaces {
  public interface IInspectionTypesService {
    Task<IEnumerable<InspectionType>> GetInspectionTypes();

    Task<InspectionType> GetInspectionType(int id);

    Task<bool> PutInspectionType(int id, InspectionType inspectionType);

    Task<InspectionType> PostInspectionType(InspectionType inspectionType);

    Task<bool> DeleteInspectionType(int id);
  }
}

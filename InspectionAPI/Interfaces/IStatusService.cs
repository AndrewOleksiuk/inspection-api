using InspectionAPI.Models;

namespace InspectionAPI.Interfaces {
  public interface IStatusService {
    Task<IEnumerable<Status>> GetStatuses();

    Task<Status> GetStatus(int id);

    Task<bool> PutStatus(int id, Status status);

    Task<Status> PostStatus(Status status);

    Task<bool> DeleteStatus(int id);
  }
}

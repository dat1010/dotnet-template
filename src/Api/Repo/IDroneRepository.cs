using Api.Models;

namespace Api.Repo;

public interface IDroneRepository
{
    Task<IEnumerable<Drone>> ListDrones();
    // Task<Drone> GetDroneById(int id);
    // Task AddDrone(Drone drone);
    // Task UpdateDrone(Drone drone);
    // Task DeleteDrone(int id);
}

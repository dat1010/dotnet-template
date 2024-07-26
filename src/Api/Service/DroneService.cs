using Api.Repo;
using Api.Models;

namespace Api.Service;

public class DroneService
{
    private readonly IDroneRepository _droneRepository;

    public DroneService(IDroneRepository droneRepository)
    {
        _droneRepository = droneRepository;
    }

    public async Task<IEnumerable<Drone>> ListDrones()
    {
        return await _droneRepository.ListDrones();
    }
}


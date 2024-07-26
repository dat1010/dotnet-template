using Api.Repo;
using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Data;

public class DroneRepository : IDroneRepository
{
    private readonly AppDbContext _context;

    public DroneRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Drone>> ListDrones()
    {
        return await _context.Drones.ToListAsync();
    }
}

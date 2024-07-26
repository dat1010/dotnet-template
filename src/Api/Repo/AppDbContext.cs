using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Repo;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Drone> Drones { get; set; }

}


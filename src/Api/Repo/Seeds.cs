using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Repo;

public static class Seeds
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using var context = new AppDbContext(serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>());

        if (context.Drones.Any())
        {
            return;   // DB has been seeded
        }

        context.Drones.AddRange(
            new Drone
            {
                Frame = "Quadcopter",
                Motor = "Brushless",
                VideoTransmitterType = "Analog",
                Receiver = "FrSky"
            },
            new Drone
            {
                Frame = "Hexacopter",
                Motor = "Brushless",
                VideoTransmitterType = "Digital",
                Receiver = "Spektrum"
            },
            new Drone
            {
                Frame = "Tricopter",
                Motor = "Brushed",
                VideoTransmitterType = "Analog",
                Receiver = "FlySky"
            },
            new Drone
            {
                Frame = "Octocopter",
                Motor = "Brushless",
                VideoTransmitterType = "Digital",
                Receiver = "TBS Crossfire"
            }
        );

        context.SaveChanges();
    }
}

using Api.Models;
using MediatR;
using Carter;
using Mapster;

namespace Api.Endpoints;

public record ListDronesResponse(IEnumerable<Drone> Drones);

public class DroneEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/drone", async (ISender sender) =>
        {
            var result = await sender.Send(new ListDronesRequest());
            var response = result.Adapt<ListDronesResponse>();
            return Results.Ok(response);
        })
        .WithName("ListDrones")
        .Produces<IEnumerable<ListDronesResponse>>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("List Drones")
        .WithDescription("List Drones");
    }
}

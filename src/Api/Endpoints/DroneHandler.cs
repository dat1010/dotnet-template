using Api.Repo;
using Api.Models;
using MediatR;

namespace Api.Endpoints;

public record ListDronesRequest : IRequest<ListDroneResults> { }
public record ListDroneResults(IEnumerable<Drone> Drones);

public class DroneHandler : IRequestHandler<ListDronesRequest, ListDroneResults>
{
    private readonly IDroneRepository _repository;

    public DroneHandler(IDroneRepository repository)
    {
        _repository = repository;
    }

    public async Task<ListDroneResults> Handle(ListDronesRequest request, CancellationToken cancellationToken)
    {
        var result = await _repository.ListDrones();

        return new ListDroneResults(result);
    }
}

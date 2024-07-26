# dotnet-template

# .NET Minimal API Template with Carter and MediatR

This template sets up a .NET 8 minimal API using Carter for routing and MediatR for handling requests and responses.

## Prerequisites

- [.NET SDK 8.0 or later](https://dotnet.microsoft.com/download)
- [Visual Studio Code](https://code.visualstudio.com/) (or any preferred IDE)
- [Docker](https://docs.docker.com/engine/install/)
- [Docker-Compose](https://docs.docker.com/compose/install/)

## Getting Started


1. **Clone the Repository**

   ```bash
   git clone https://github.com/your-repo/dotnet-minimal-api-template.git
   cd dotnet-minimal-api-template
   ```

2. **Restore Dependencies**

   ```bash
   dotnet restore
   ```

3. **Run the Application**

   ```bash
   dotnet run
   ```

   The application will start on \`http://localhost:5000\`.

## Project Structure

```
dotnet-minimal-api-template/
├── Controllers/
│   └── DroneEndpoint.cs
├── Features/
│   └── Drones/
│       ├── ListDronesRequest.cs
│       ├── ListDronesResponse.cs
│       └── ListDronesHandler.cs
├── Program.cs
├── Startup.cs
└── dotnet-minimal-api-template.csproj
```

## Adding New Features

### 1. Create a New Endpoint

Create a new file in the `Controllers\` folder for your endpoint.

```csharp
// Controllers/DroneEndpoint.cs
public record ListDronesResponse(Drone Drone);

public class DroneEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/drone", async (ISender sender) =>
        {
            var result = await sender.Send(new ListDronesRequest());
            var response = result.Drones.Adapt<IEnumerable<ListDronesResponse>>();
            return Results.Ok(response);
        })
        .WithName("ListDrones")
        .Produces<IEnumerable<ListDronesResponse>>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("List Drones")
        .WithDescription("List Drones");
    }
}
```

### 2. Create a Request and Handler

Create a new folder in the `Features\` directory for your feature.

```csharp
// Features/Drones/ListDronesRequest.cs
using MediatR;

public record ListDronesRequest : IRequest<ListDronesResponse>;
```

```csharp
// Features/Drones/ListDronesResponse.cs
public record ListDronesResponse(IEnumerable<Drone> Drones);
```

```csharp
// Features/Drones/ListDronesHandler.cs
using MediatR;
using System.Threading;
using System.Threading.Tasks;

public class ListDronesHandler : IRequestHandler<ListDronesRequest, ListDronesResponse>
{
    public Task<ListDronesResponse> Handle(ListDronesRequest request, CancellationToken cancellationToken)
    {
        var drones = // Fetch drones from your data source
        return Task.FromResult(new ListDronesResponse(drones));
    }
}
```

## Configuration

### Program.cs

Configure your application in \`Program.cs\`.

```csharp
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCarter();
builder.Services.AddMediatR(typeof(Program).Assembly);

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapCarter();

app.Run();
```

### Startup.cs

You can also add configurations in \`Startup.cs\` if needed.

```csharp
public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddCarter();
        services.AddMediatR(typeof(Startup).Assembly);
    }

    public void Configure(IApplicationBuilder app)
    {
        app.UseRouting();
        app.UseEndpoints(endpoints => endpoints.MapCarter());
    }
}
```

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.

using Microsoft.AspNetCore.Routing;

namespace Shared.Extensions.MinimalApiExtensions;

public interface IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder builder);
}
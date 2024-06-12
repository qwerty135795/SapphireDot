using FluentValidation;
using FluentValidation.AspNetCore;
using MessageService.Data;
using MessageService.Extensions;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Shared.Extensions.MinimalApiExtensions;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();

try
{
    var builder = WebApplication.CreateBuilder(args);

    builder.Services.AddSerilog();
    builder.Services.AddAutoMapper(opt
        => opt.AddMaps(typeof(Program).Assembly));
    builder.Services.AddMediatR(opt
        => opt.RegisterServicesFromAssembly(typeof(Program).Assembly));
    builder.Services.AddEndpoints(typeof(Program).Assembly);
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services.AddDbContext<MessageContext>(opt =>
    {
        opt.UseSqlite(builder.Configuration.GetConnectionString("default"));
    });
    builder.Services.AddValidatorsFromAssembly(typeof(Program).Assembly);
    var app = builder.Build();
    app.UseSerilogRequestLogging();
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    RouteGroupBuilder routes = app.MapGroup("api").WithOpenApi();
    app.MapEndpoints(routes);
    app.Run();

}
catch (Exception ex) when(ex is not HostAbortedException)
{
    Log.Fatal(ex, "Unhandled error");
}
finally
{
    await Log.CloseAndFlushAsync();
}

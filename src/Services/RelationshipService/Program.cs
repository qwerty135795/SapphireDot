using Microsoft.EntityFrameworkCore;
using RelationshipService.Data;
using Shared.Extensions.MassTransit;
using Shared.Extensions.MinimalApiExtensions;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddDbContext<RelationshipContext>(opt =>
    opt.UseSqlite(builder.Configuration.GetConnectionString("default")));
builder.Services.AddEndpoints(typeof(Program).Assembly);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddConfiguredMassTransit(typeof(Program).Assembly);
builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddMediatR(opt =>
    opt.RegisterServicesFromAssembly(typeof(Program).Assembly));

var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

var group = app.MapGroup("aoi").WithOpenApi();
app.MapEndpoints(group);

app.Run();


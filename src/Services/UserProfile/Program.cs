using Microsoft.EntityFrameworkCore;
using Shared.Extensions.MinimalApiExtensions;
using UserProfile.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ProfileContext>(opt =>
    opt.UseSqlite(builder.Configuration.GetConnectionString("default")));
builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddMediatR(opt =>
    opt.RegisterServicesFromAssembly(typeof(Program).Assembly));
builder.Services.AddEndpoints(typeof(Program).Assembly);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

var groups = app.MapGroup("api").WithOpenApi();
app.MapEndpoints(groups);
app.Run();


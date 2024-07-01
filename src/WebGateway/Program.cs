var builder = WebApplication.CreateBuilder(args);
builder.Services.AddReverseProxy()
    .LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));
builder.Services.AddAuthorization(opt =>
{
    opt.AddPolicy("authenticated",
        pol => pol.RequireAuthenticatedUser());
});
var app = builder.Build();
app.UseAuthentication();
app.UseAuthorization();
app.MapReverseProxy();

app.Run();
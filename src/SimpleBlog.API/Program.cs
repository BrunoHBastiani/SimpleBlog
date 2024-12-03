using SimpleBlog.API.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.AddArchitectures();
builder.AddServices();

var app = builder.Build();
app.UseArchitectures();
app.Run();

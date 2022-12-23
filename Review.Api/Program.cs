using Serilog;
using GoSolve.Dummy.Review.Api.ExtensionMethods;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog();

builder.Services.AddApiLayer(builder.Configuration);

var app = builder.Build();

app.UseApiLayer();

app.Run();

using GoSolve.Dummy.Review.Api.Business.MappingProfiles;
using GoSolve.Dummy.Review.Api.Business.Services;
using GoSolve.Dummy.Review.Api.Business.Services.Interfaces;
using GoSolve.Tools.Api.ExtensionMethods;

var builder = WebApplication.CreateBuilder(args);

// builder.Host.UseSerilog();

// Add services to the container.
builder.Services.AddTransient<IReviewService, ReviewService>();
builder.Services.AddAutoMapper(typeof(DtoMappingProfiles));
builder.Services.AddApiTools();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseApiTools();

app.Run();

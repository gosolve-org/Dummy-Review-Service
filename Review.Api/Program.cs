using GoSolve.Dummy.Review.Api.Business.ExtensionMethods;
using GoSolve.Dummy.Review.Api.Business.Services;
using GoSolve.Dummy.Review.Api.Business.Services.Interfaces;
using GoSolve.Dummy.Review.Api.Data;
using GoSolve.Dummy.Review.Api.Data.Repositories;
using GoSolve.Dummy.Review.Api.MappingProfiles;
using GoSolve.Tools.Api.ExtensionMethods;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// builder.Host.UseSerilog();

// Add services to the container.
builder.Services.AddAutoMapper(typeof(DtoMappingProfiles));
builder.Services.AddApiTools();
builder.Services.AddBusinessLayer(builder.Configuration);

var app = builder.Build();

app.UseApiTools();
app.UseBusinessLayer();

app.Run();

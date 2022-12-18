using GoSolve.Dummy.Review.Api.Business.MappingProfiles;
using GoSolve.Dummy.Review.Api.Business.Services;
using GoSolve.Dummy.Review.Api.Business.Services.Interfaces;
using GoSolve.Dummy.Review.Api.Data.ExtensionMethods;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GoSolve.Dummy.Review.Api.Business.ExtensionMethods;

public static class BusinessExtensionMethods
{
    public static void AddBusinessLayer(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAutoMapper(typeof(DtoMappingProfiles));

        services.AddDataLayer(configuration);

        services.AddTransient<IReviewService, ReviewService>();
    }

    public static void UseBusinessLayer(this WebApplication app)
    {
        app.UseDataLayer();
    }
}

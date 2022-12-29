using GoSolve.Dummy.Review.Business.MappingProfiles;
using GoSolve.Dummy.Review.Business.Services;
using GoSolve.Dummy.Review.Business.Services.Interfaces;
using GoSolve.Dummy.Review.Data.ExtensionMethods;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GoSolve.Dummy.Review.Business.ExtensionMethods;

public static class PipelineExtensionMethods
{
    public static IServiceCollection AddBusinessLayer(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAutoMapper(typeof(DtoMappingProfile));

        services.AddDataLayer(configuration);

        services.AddTransient<IReviewService, ReviewService>();

        return services;
    }
}

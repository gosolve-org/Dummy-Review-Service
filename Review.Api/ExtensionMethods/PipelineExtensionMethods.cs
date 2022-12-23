using GoSolve.Dummy.Review.Api.MappingProfiles;
using GoSolve.Dummy.Review.Business.ExtensionMethods;
using GoSolve.Dummy.Review.Business.Services;
using GoSolve.Dummy.Review.Business.Services.Interfaces;
using GoSolve.Dummy.Review.Data;
using GoSolve.Dummy.Review.Data.ExtensionMethods;
using GoSolve.Tools.Api.ExtensionMethods;

namespace GoSolve.Dummy.Review.Api.ExtensionMethods;

public static class PipelineExtensionMethods
{
    public static IServiceCollection AddApiLayer(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAutoMapper(typeof(DtoMappingProfile));
        services.AddApiTools(configuration);
        services.AddBusinessLayer(configuration);

        return services;
    }

    public static WebApplication UseApiLayer(this WebApplication app)
    {
        app.UseApiTools();
        app.MigrateDatabase<ReviewDbContext>();

        return app;
    }
}

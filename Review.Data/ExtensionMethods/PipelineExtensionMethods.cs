using GoSolve.Dummy.Review.Data.Repositories;
using GoSolve.Dummy.Review.Data.Repositories.Interfaces;
using GoSolve.Tools.Common.ExtensionMethods;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GoSolve.Dummy.Review.Data.ExtensionMethods;

public static class PipelineExtensionMethods
{
    public static IServiceCollection AddDataLayer(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDatabaseTools<ReviewDbContext>(configuration);

        services.AddTransient<IReviewRepository, ReviewRepository>();

        return services;
    }
}

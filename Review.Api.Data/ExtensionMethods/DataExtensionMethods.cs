using GoSolve.Dummy.Review.Api.Data.Repositories;
using GoSolve.Tools.Api.ExtensionMethods;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GoSolve.Dummy.Review.Api.Data.ExtensionMethods;

public static class DataExtensionMethods
{
    public static void AddDataLayer(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDatabaseTools<ReviewDbContext>(configuration);

        services.AddTransient<IReviewRepository, ReviewRepository>();
    }

    public static void UseDataLayer(this WebApplication app)
    {
        app.UseDatabaseTools<ReviewDbContext>();
    }
}

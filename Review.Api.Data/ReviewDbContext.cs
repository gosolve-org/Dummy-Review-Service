using GoSolve.Tools.Api.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace GoSolve.Dummy.Review.Api.Data;

public class ReviewDbContext : BaseDbContext<ReviewDbContext>
{
    public DbSet<Models.Review> Reviews { get; set; }

    public ReviewDbContext(DbContextOptions<ReviewDbContext> options)
        : base(options)
    {
    }
}

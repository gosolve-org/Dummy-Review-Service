using GoSolve.Dummy.Review.Data.Models;
using GoSolve.Dummy.Review.Data.Seeders;
using GoSolve.Tools.Common.Database.Models;
using GoSolve.Tools.Common.ExtensionMethods;
using Microsoft.EntityFrameworkCore;

namespace GoSolve.Dummy.Review.Data;

public class ReviewDbContext : BaseDbContext<ReviewDbContext>
{
    public DbSet<Models.Review> Reviews { get; set; }
    public DbSet<ReviewAuthorType> ReviewAuthorTypes { get; set; }

    public ReviewDbContext(DbContextOptions<ReviewDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Models.Review>()
            .HasOne(r => r.AuthorType)
            .WithMany();

        modelBuilder.SeedCoreData(builder =>
            builder.AddSeeder<ReviewAuthorTypeSeeder>());
    }
}

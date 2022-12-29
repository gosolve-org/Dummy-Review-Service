using GoSolve.Dummy.Review.Data.Models;
using GoSolve.Tools.Common.Database.Models;
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

        modelBuilder.Entity<ReviewAuthorType>()
            .HasData(
                new ReviewAuthorType { Id = 1, Type = "Reader" },
                new ReviewAuthorType { Id = 2, Type = "Publisher" },
                new ReviewAuthorType { Id = 3, Type = "Official reviewer" });
    }
}

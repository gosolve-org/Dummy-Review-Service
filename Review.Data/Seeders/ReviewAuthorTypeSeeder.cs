using GoSolve.Dummy.Review.Data.Models;
using GoSolve.Tools.Common.Database.Models;
using GoSolve.Tools.Common.Database.Seeding.Interfaces;

namespace GoSolve.Dummy.Review.Data.Seeders;

public class ReviewAuthorTypeSeeder : ICoreDataSeeder
{
    public IEnumerable<TimestampedEntity> BuildData()
    {
        return new ReviewAuthorType[]
        {
            new ReviewAuthorType { Id = 1, Type = "Reader" },
            new ReviewAuthorType { Id = 2, Type = "Publisher" },
            new ReviewAuthorType { Id = 3, Type = "Official reviewer" }
        };
    }
}

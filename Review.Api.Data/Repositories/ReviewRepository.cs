using GoSolve.Tools.Api.Database.Repositories;

namespace GoSolve.Dummy.Review.Api.Data.Repositories;

public class ReviewRepository : GenericRepository<Models.Review, long, ReviewDbContext>, IReviewRepository
{
    public ReviewRepository(ReviewDbContext context)
        : base(context)
    {
    }
}

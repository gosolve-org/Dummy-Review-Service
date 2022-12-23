using GoSolve.Dummy.Review.Data.Repositories.Interfaces;
using GoSolve.Tools.Common.Database.Repositories;

namespace GoSolve.Dummy.Review.Data.Repositories;

public class ReviewRepository : GenericRepository<Models.Review, long, ReviewDbContext>, IReviewRepository
{
    public ReviewRepository(ReviewDbContext context)
        : base(context)
    {
    }
}

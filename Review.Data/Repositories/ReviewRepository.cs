namespace GoSolve.Dummy.Review.Data.Repositories;

public class ReviewRepository : GenericRepository<Models.Review, long, ReviewDbContext>, IReviewRepository
{
    public ReviewRepository(ReviewDbContext context)
        : base(context)
    {
    }
}

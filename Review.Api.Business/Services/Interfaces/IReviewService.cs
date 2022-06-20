namespace GoSolve.Dummy.Review.Api.Business.Services.Interfaces;

public interface IReviewService
{
    Task<IEnumerable<Models.Review>> GetReviews(string author);

    Task<Models.Review> GetReviewById(int reviewId);

    Task<IEnumerable<Models.Review>> GetReviewsForBook(int bookId);

    Task<Models.Review> AddReview(Models.Review reviewRequest);
}

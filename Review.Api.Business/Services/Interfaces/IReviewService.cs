using GoSolve.HttpClients.Dummy.Review.Contracts;

namespace GoSolve.Dummy.Review.Api.Business.Services.Interfaces;

public interface IReviewService
{
    Task<IEnumerable<ReviewResponse>> GetReviews(string author);

    Task<ReviewResponse> GetReviewById(int reviewId);

    Task<IEnumerable<ReviewResponse>> GetReviewsForBook(int bookId);

    Task<ReviewResponse> AddReview(ReviewRequest reviewRequest);
}

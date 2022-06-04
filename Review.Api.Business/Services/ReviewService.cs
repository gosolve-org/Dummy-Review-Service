using AutoMapper;
using GoSolve.Dummy.Review.Api.Business.Services.Interfaces;
using GoSolve.HttpClients.Dummy.Review.Contracts;

namespace GoSolve.Dummy.Review.Api.Business.Services
{
    public class ReviewService : IReviewService
    {
        private IMapper _mapper;

        private Models.Review[] _reviewDb = new Models.Review[]
        {
            new Models.Review { Id = 0, BookId = 0, Author = "Bob Anderson", Rating = 5, Comment = "Amazing!" },
            new Models.Review { Id = 1, BookId = 0, Author = "Alice", Rating = 4, Comment = "Good book!" },
            new Models.Review { Id = 2, BookId = 1, Author = "Bob Anderson", Rating = 2, Comment = "Did not like it." },
        };

        public ReviewService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<ReviewResponse> AddReview(ReviewRequest reviewRequest)
        {
            var review = _mapper.Map<Models.Review>(reviewRequest);
            review.Id = 201;
            return _mapper.Map<ReviewResponse>(review);
        }

        public async Task<ReviewResponse> GetReviewById(int reviewId)
        {
            var review = _reviewDb.FirstOrDefault(review => review.Id == reviewId);
            if (review == null) return null;

            return _mapper.Map<ReviewResponse>(review);
        }

        public async Task<IEnumerable<ReviewResponse>> GetReviews(string author)
        {
            var reviews = _reviewDb
                .Where(review => string.Equals(review.Author, author, StringComparison.CurrentCultureIgnoreCase));

            return _mapper.Map<IEnumerable<ReviewResponse>>(reviews);
        }

        public async Task<IEnumerable<ReviewResponse>> GetReviewsForBook(int bookId)
        {
            var reviews = _reviewDb
                .Where(review => review.BookId == bookId);

            return _mapper.Map<IEnumerable<ReviewResponse>>(reviews);
        }
    }
}

using GoSolve.Clients.Dummy.Review.Contracts.Requests;
using GoSolve.Clients.Dummy.Review.Contracts.Responses;
using Microsoft.AspNetCore.JsonPatch;

namespace GoSolve.Dummy.Review.Business.Services.Interfaces;

public interface IReviewService
{
    Task<IEnumerable<ReviewResponse>> GetByAuthor(string author);

    Task<ReviewResponse> GetById(long id);

    Task<IEnumerable<ReviewResponse>> GetByBookId(long bookId);

    Task<ReviewResponse> Add(ReviewCreationRequest review);

    Task Update(ReviewUpdateRequest review);

    Task Patch(long id, JsonPatchDocument<ReviewPatchRequest> patchDoc);

    Task DeleteById(long id);

    Task<IEnumerable<ReviewAuthorTypeResponse>> GetAuthorTypes();
}

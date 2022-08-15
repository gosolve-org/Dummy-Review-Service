using Microsoft.AspNetCore.JsonPatch;

namespace GoSolve.Dummy.Review.Api.Business.Services.Interfaces;

public interface IReviewService
{
    Task<IEnumerable<Models.Review>> GetByAuthor(string author);

    Task<Models.Review> GetById(long id);

    Task<IEnumerable<Models.Review>> GetByBookId(long bookId);

    Task<Models.Review> Add(Models.Review review);

    Task Update(Models.Review review);

    Task Patch(long id, JsonPatchDocument<Models.Review> patchDoc);

    Task DeleteById(long id);
}

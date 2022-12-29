using AutoMapper;
using GoSolve.Clients.Dummy.Review.Contracts.Requests;
using GoSolve.Clients.Dummy.Review.Contracts.Responses;
using GoSolve.Dummy.Review.Business.Services.Interfaces;
using GoSolve.Dummy.Review.Data;
using GoSolve.Dummy.Review.Data.Models;
using GoSolve.Dummy.Review.Data.Repositories;
using GoSolve.Dummy.Review.Data.Repositories.Interfaces;
using GoSolve.Tools.Common.Database.Models;
using GoSolve.Tools.Common.Database.Models.Interfaces;
using GoSolve.Tools.Common.Exceptions;
using Microsoft.AspNetCore.JsonPatch;

namespace GoSolve.Dummy.Review.Business.Services;

public class ReviewService : IReviewService
{
    private IMapper _mapper;
    private IUnitOfWork _unitOfWork;
    private IReviewRepository _reviewRepository;
    private IReviewAuthorTypeRepository _reviewAuthorTypeRepository;

    public ReviewService(
        IMapper mapper,
        IUnitOfWork unitOfWork,
        IReviewRepository reviewRepository,
        IReviewAuthorTypeRepository reviewAuthorTypeRepository)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _reviewRepository = reviewRepository;
        _reviewAuthorTypeRepository = reviewAuthorTypeRepository;
    }

    public async Task<ReviewResponse> GetById(long id)
    {
        var review = await _reviewRepository.GetById(id);
        if (review == null) return null;

        return _mapper.Map<ReviewResponse>(review);
    }

    public async Task<IEnumerable<ReviewResponse>> GetByAuthor(string author)
    {
        var reviews = await _reviewRepository
            .Find(review => review.Author.ToLower() == author.ToLower());

        return _mapper.Map<IEnumerable<ReviewResponse>>(reviews);
    }

    public async Task<IEnumerable<ReviewResponse>> GetByBookId(long bookId)
    {
        var reviews = await _reviewRepository.Find(review => review.BookId == bookId);

        return _mapper.Map<IEnumerable<ReviewResponse>>(reviews);
    }

    public async Task<ReviewResponse> Add(ReviewCreationRequest review)
    {
        var reviewAuthorType = await _reviewAuthorTypeRepository.GetById(review.AuthorTypeId);
        if (reviewAuthorType == null)
        {
            throw new ArgumentException($"Could not find ReviewAuthorType by id {review.AuthorTypeId}.");
        }

        var reviewEntity = _mapper.Map<Data.Models.Review>(review);
        reviewEntity.CreatedAt = DateTime.UtcNow; // TODO: Should this be set manually? Doesn't our tooling add this?
        reviewEntity.UpdatedAt = DateTime.UtcNow; // TODO: Should this be set manually? Doesn't our tooling add this?

        _reviewRepository.Add(reviewEntity);

        await _unitOfWork.CompleteAsync();

        return _mapper.Map<ReviewResponse>(reviewEntity);
    }

    public async Task Update(ReviewUpdateRequest review)
    {
        var reviewEntity = await _reviewRepository.GetById(review.Id);
        var reviewAuthorType = await _reviewAuthorTypeRepository.GetById(review.AuthorTypeId);

        if (reviewEntity == null) throw new NotFoundException($"Review with id {review.Id} does not exist.");

        if (reviewAuthorType == null)
        {
            throw new ArgumentException($"Could not find ReviewAuthorType by id {review.AuthorTypeId}.");
        }

        reviewEntity.Author = review.Author;
        reviewEntity.BookId = review.BookId;
        reviewEntity.Comment = review.Comment;
        reviewEntity.Rating = review.Rating;
        reviewEntity.AuthorTypeId = review.AuthorTypeId;

        await _unitOfWork.CompleteAsync();
    }

    public async Task Patch(long id, JsonPatchDocument<ReviewPatchRequest> patchDoc)
    {
        var reviewEntity = await _reviewRepository.GetById(id);
        if (reviewEntity == null) throw new NotFoundException($"Review with id {id} does not exist.");

        var entityPatchDoc = _mapper.Map<JsonPatchDocument<Data.Models.Review>>(patchDoc);

        entityPatchDoc.ApplyTo(reviewEntity);

        var reviewAuthorType = await _reviewAuthorTypeRepository.GetById(reviewEntity.AuthorTypeId);
        if (reviewAuthorType == null)
        {
            throw new ArgumentException($"Could not find ReviewAuthorType by id {reviewEntity.AuthorTypeId}.");
        }

        await _unitOfWork.CompleteAsync();
    }

    public async Task DeleteById(long id)
    {
        var reviewEntity = await _reviewRepository.GetById(id);
        if (reviewEntity == null) throw new NotFoundException($"Review with id {id} does not exist.");

        _reviewRepository.Remove(reviewEntity);

        await _unitOfWork.CompleteAsync();
    }

    public async Task<IEnumerable<ReviewAuthorTypeResponse>> GetAuthorTypes()
    {
        var authorTypes = await _reviewAuthorTypeRepository.GetAll();

        return _mapper.Map<IEnumerable<ReviewAuthorTypeResponse>>(authorTypes);
    }
}

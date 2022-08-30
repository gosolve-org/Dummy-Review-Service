using AutoMapper;
using GoSolve.Dummy.Review.Api.Business.Services.Interfaces;
using GoSolve.Dummy.Review.Api.Data;
using GoSolve.Dummy.Review.Api.Data.Repositories;
using GoSolve.Tools.Api.Database.Models;
using GoSolve.Tools.Common.Exceptions;
using Microsoft.AspNetCore.JsonPatch;

namespace GoSolve.Dummy.Review.Api.Business.Services;

public class ReviewService : IReviewService
{
    private IMapper _mapper;
    private IUnitOfWork _unitOfWork;
    private IReviewRepository _reviewRepository;

    public ReviewService(IMapper mapper, IUnitOfWork unitOfWork, IReviewRepository reviewRepository)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _reviewRepository = reviewRepository;
    }

    public async Task<Models.Review> GetById(long id)
    {
        var review = await _reviewRepository.GetById(id);
        if (review == null) return null;

        return _mapper.Map<Models.Review>(review);
    }

    public async Task<IEnumerable<Models.Review>> GetByAuthor(string author)
    {
        var reviews = await _reviewRepository
            .Find(review => review.Author.ToLower() == author.ToLower());

        return _mapper.Map<IEnumerable<Models.Review>>(reviews);
    }

    public async Task<IEnumerable<Models.Review>> GetByBookId(long bookId)
    {
        var reviews = await _reviewRepository.Find(review => review.BookId == bookId);

        return _mapper.Map<IEnumerable<Models.Review>>(reviews);
    }

    public async Task<Models.Review> Add(Models.Review review)
    {
        // TODO: (not relevant to this scope) Add volume to docker-compose for live reload (& debugging??)
        // TODO: (not relevant to this scope) Add seed scripts for db (db gets reset on docker compose start, what are the conventions for this? -> research)
        var reviewEntity = _mapper.Map<Data.Models.Review>(review);
        reviewEntity.CreatedAt = DateTime.UtcNow;
        reviewEntity.UpdatedAt = DateTime.UtcNow;

        _reviewRepository.Add(reviewEntity);

        await _unitOfWork.CompleteAsync();

        return _mapper.Map<Models.Review>(reviewEntity);
    }

    public async Task Update(Models.Review review)
    {
        var reviewEntity = await _reviewRepository.GetById(review.Id);
        if (reviewEntity == null) throw new NotFoundException($"Review with id {review.Id} does not exist.");
        reviewEntity.Author = review.Author;
        reviewEntity.BookId = review.BookId;
        reviewEntity.Comment = review.Comment;
        reviewEntity.Rating = review.Rating;

        await _unitOfWork.CompleteAsync();
    }

    public async Task Patch(long id, JsonPatchDocument<Models.Review> patchDoc)
    {
        var reviewEntity = await _reviewRepository.GetById(id);
        if (reviewEntity == null) throw new NotFoundException($"Review with id {id} does not exist.");

        var entityPatchDoc = _mapper.Map<JsonPatchDocument<Data.Models.Review>>(patchDoc);

        entityPatchDoc.ApplyTo(reviewEntity);

        await _unitOfWork.CompleteAsync();
    }

    public async Task DeleteById(long id)
    {
        var reviewEntity = await _reviewRepository.GetById(id);
        if (reviewEntity == null) throw new NotFoundException($"Review with id {id} does not exist.");

        _reviewRepository.Remove(reviewEntity);

        await _unitOfWork.CompleteAsync();
    }
}

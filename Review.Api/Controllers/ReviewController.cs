using System.ComponentModel.DataAnnotations;
using AutoMapper;
using GoSolve.Dummy.Review.Api.Business.Services.Interfaces;
using GoSolve.HttpClients.Dummy.Review.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace GoSolve.Dummy.Review.Api.Controllers;

[ApiController]
[ApiVersion("1")]
[Route("/api/v{version:apiVersion}")]
public class ReviewController : ControllerBase
{
    private readonly IReviewService _reviewService;
    private readonly IMapper _mapper;

    public ReviewController(IReviewService reviewService, IMapper mapper)
    {
        _reviewService = reviewService;
        _mapper = mapper;
    }

    [HttpGet("reviews")]
    public async Task<IActionResult> GetReviews([FromQuery] [Required] string author)
    {
        if (string.IsNullOrWhiteSpace(author)) throw new ArgumentException("Missing required query parameter: author.");
        return Ok(_mapper.Map<IEnumerable<ReviewResponse>>(await _reviewService.GetReviews(author)));
    }

    [HttpGet("reviews/{reviewId}")]
    public async Task<IActionResult> GetReviewById(int reviewId)
    {
        var review = await _reviewService.GetReviewById(reviewId);
        if (review == null) return NotFound();

        return Ok(_mapper.Map<ReviewResponse>(review));
    }

    [HttpGet("books/{bookId}/reviews")]
    public async Task<IActionResult> GetReviewsForBook(int bookId)
    {
        return Ok(_mapper.Map<IEnumerable<ReviewResponse>>(await _reviewService.GetReviewsForBook(bookId)));
    }

    [HttpPost("reviews")]
    public async Task<IActionResult> AddReview(ReviewRequest reviewRequest)
    {
        var review = _mapper.Map<Business.Models.Review>(reviewRequest);
        var reviewResponse = _mapper.Map<ReviewResponse>(await _reviewService.AddReview(review));
        return CreatedAtAction(nameof(GetReviewById), new { reviewId = reviewResponse.Id }, reviewResponse);
    }
}

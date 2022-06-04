using System.ComponentModel.DataAnnotations;
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

    public ReviewController(IReviewService reviewService)
    {
        _reviewService = reviewService;
    }

    [HttpGet("reviews")]
    public async Task<IActionResult> GetReviews([FromQuery] [Required] string author)
    {
        if (string.IsNullOrWhiteSpace(author)) throw new ArgumentException("Missing required query parameter: author.");
        return Ok(await _reviewService.GetReviews(author));
    }

    [HttpGet("reviews/{reviewId}")]
    public async Task<IActionResult> GetReviewById(int reviewId)
    {
        var review = await _reviewService.GetReviewById(reviewId);
        if (review == null) return NotFound();

        return Ok(review);
    }

    [HttpGet("books/{bookId}/reviews")]
    public async Task<IActionResult> GetReviewsForBook(int bookId)
    {
        return Ok(await _reviewService.GetReviewsForBook(bookId));
    }

    [HttpPost("reviews")]
    public IActionResult AddReview(ReviewRequest reviewRequest)
    {
        var reviewResponse = _reviewService.AddReview(reviewRequest);
        return CreatedAtAction(nameof(GetReviewById), new { reviewId = reviewResponse.Id }, reviewResponse);
    }
}

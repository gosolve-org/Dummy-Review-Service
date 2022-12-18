using AutoMapper;
using GoSolve.Dummy.Review.Api.Business.Services.Interfaces;
using GoSolve.HttpClients.Dummy.Review.Contracts;
using GoSolve.Tools.Common.Exceptions;
using GoSolve.Tools.Api.ExtensionMethods;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.JsonPatch;

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
    public async Task<IActionResult> GetReviews([FromQuery][Required] string author)
    {
        if (string.IsNullOrWhiteSpace(author)) throw new ArgumentException("Missing required query parameter: author.");
        return Ok(_mapper.Map<IEnumerable<ReviewResponse>>(await _reviewService.GetByAuthor(author)));
    }

    [HttpGet("reviews/{id}")]
    public async Task<IActionResult> GetReviewById(int id)
    {
        var review = await _reviewService.GetById(id);
        if (review == null) return NotFound();

        return Ok(_mapper.Map<ReviewResponse>(review));
    }

    [HttpGet("books/{bookId}/reviews")]
    public async Task<IActionResult> GetReviewsForBook(int bookId)
    {
        return Ok(_mapper.Map<IEnumerable<ReviewResponse>>(await _reviewService.GetByBookId(bookId)));
    }

    [HttpPost("reviews")]
    public async Task<IActionResult> AddReview(ReviewPostRequest reviewRequest)
    {
        var review = _mapper.Map<Business.Models.Review>(reviewRequest);
        var reviewResponse = _mapper.Map<ReviewResponse>(await _reviewService.Add(review));
        return CreatedAtAction(nameof(GetReviewById), new { id = reviewResponse.Id }, reviewResponse);
    }

    [HttpPut("reviews/{id}")]
    public async Task<IActionResult> UpdateReview(long id, ReviewPutRequest reviewRequest)
    {
        if (id != reviewRequest.Id)
        {
            throw new ArgumentException("You can not change the id of a review.");
        }

        var review = _mapper.Map<Business.Models.Review>(reviewRequest);
        await _reviewService.Update(review);

        return NoContent();
    }

    [HttpDelete("reviews/{id}")]
    public async Task<IActionResult> DeleteReview(long id)
    {
        await _reviewService.DeleteById(id);

        return NoContent();
    }

    [HttpPatch("reviews/{id}")]
    public async Task<IActionResult> PatchReview(long id, [FromBody] JsonPatchDocument<ReviewPatchRequest> patchDoc)
    {
        var review = await _reviewService.GetById(id);
        if (review == null) return NotFound();
        if (!patchDoc.ApplyAndValidate(this, _mapper.Map<ReviewPatchRequest>(review)))
        {
            return ValidationProblem();
        }

        await _reviewService.Patch(id, _mapper.Map<JsonPatchDocument<Business.Models.Review>>(patchDoc));

        return NoContent();
    }
}

using AutoMapper;
using GoSolve.Dummy.Review.Business.Services.Interfaces;
using GoSolve.Tools.Common.Exceptions;
using GoSolve.Tools.Api.ExtensionMethods;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.JsonPatch;
using GoSolve.Clients.Dummy.Review.Contracts.Responses;
using GoSolve.Clients.Dummy.Review.Contracts.Requests;

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
    public async Task<IActionResult> Get([FromQuery][Required] string author)
    {
        if (string.IsNullOrWhiteSpace(author)) throw new ArgumentException("Missing required query parameter: author.");
        return Ok(await _reviewService.GetByAuthor(author));
    }

    [HttpGet("reviews/{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var review = await _reviewService.GetById(id);
        if (review == null) return NotFound();

        return Ok(review);
    }

    [HttpGet("books/{bookId}/reviews")]
    public async Task<IActionResult> GetForBook(int bookId)
    {
        return Ok(await _reviewService.GetByBookId(bookId));
    }

    [HttpPost("reviews")]
    public async Task<IActionResult> Add(ReviewCreationRequest reviewRequest)
    {
        var reviewResponse = await _reviewService.Add(reviewRequest);

        return CreatedAtAction(nameof(GetById), new { id = reviewResponse.Id }, reviewResponse);
    }

    [HttpPut("reviews/{id}")]
    public async Task<IActionResult> Update(long id, ReviewUpdateRequest reviewRequest)
    {
        if (id != reviewRequest.Id)
        {
            throw new ArgumentException("You can not change the id of a review.");
        }

        await _reviewService.Update(reviewRequest);

        return NoContent();
    }

    [HttpDelete("reviews/{id}")]
    public async Task<IActionResult> Delete(long id)
    {
        await _reviewService.DeleteById(id);

        return NoContent();
    }

    [HttpPatch("reviews/{id}")]
    public async Task<IActionResult> Patch(long id, [FromBody] JsonPatchDocument<ReviewPatchRequest> patchDoc)
    {
        var review = await _reviewService.GetById(id);
        if (review == null) return NotFound();
        if (!patchDoc.ApplyAndValidate(this, _mapper.Map<ReviewPatchRequest>(review)))
        {
            return ValidationProblem();
        }

        await _reviewService.Patch(id, patchDoc);

        return NoContent();
    }
}

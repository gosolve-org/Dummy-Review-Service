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
[Route("/api/v{version:apiVersion}/review-author-types")]
public class ReviewAuthorTypeController : ControllerBase
{
    private readonly IReviewService _reviewService;

    public ReviewAuthorTypeController(IReviewService reviewService)
    {
        _reviewService = reviewService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok(await _reviewService.GetAuthorTypes());
    }
}

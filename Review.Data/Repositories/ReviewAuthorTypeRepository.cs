using System.Linq.Expressions;
using System.Security.Cryptography;
using GoSolve.Dummy.Review.Data.Models;
using GoSolve.Dummy.Review.Data.Repositories.Interfaces;
using GoSolve.Tools.Common.Database.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GoSolve.Dummy.Review.Data.Repositories;

public class ReviewAuthorTypeRepository : ReadOnlyRepository<ReviewAuthorType, int, ReviewDbContext>, IReviewAuthorTypeRepository
{
    public ReviewAuthorTypeRepository(ReviewDbContext context)
        : base(context)
    {
    }
}

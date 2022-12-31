using System.Linq.Expressions;
using System.Security.Cryptography;
using GoSolve.Dummy.Review.Data.Repositories.Interfaces;
using GoSolve.Tools.Common.Database.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GoSolve.Dummy.Review.Data.Repositories;

public class ReviewRepository : GenericRepository<Models.Review, long, ReviewDbContext>, IReviewRepository
{
    public ReviewRepository(ReviewDbContext context)
        : base(context)
    {
    }

    public override async Task<Models.Review> GetById(long id)
    {
        return await Context.Reviews.Include(r => r.AuthorType).FirstOrDefaultAsync(r => r.Id == id);
    }

    public override async Task<IEnumerable<Models.Review>> GetAll()
    {
        return await Context.Reviews.Include(r => r.AuthorType).ToListAsync();
    }

    public override async Task<IEnumerable<Models.Review>> Find(Expression<Func<Models.Review, bool>> predicate)
    {
        return await Context.Reviews.Include(r => r.AuthorType).Where(predicate).ToListAsync();
    }

    public override IQueryable<Models.Review> PrepareDefaultReadSource(IQueryable<Models.Review> source)
    {
        return source.Include(r => r.AuthorType);
    }
}

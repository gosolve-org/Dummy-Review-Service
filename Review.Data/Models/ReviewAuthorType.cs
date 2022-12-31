using GoSolve.Tools.Common.Database.Models;

namespace GoSolve.Dummy.Review.Data.Models;

public class ReviewAuthorType : BaseEntity<int>
{
    public string Type { get; set; }
}

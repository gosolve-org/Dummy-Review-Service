namespace GoSolve.Dummy.Review.Api.Business.Models;

public class Review
{
    public long Id { get; set; }
    public int BookId { get; set; }
    public string Author { get; set; }
    public int Rating { get; set; }
    public string Comment { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}

namespace GoSolve.Dummy.Review.Api.Business.Models;

public class Review
{
    public int Id { get; set; }
    public int BookId { get; set; }
    public string Author { get; set; }
    public int Rating { get; set; }
    public string Comment { get; set; }
}

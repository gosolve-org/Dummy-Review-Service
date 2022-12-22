using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;
using GoSolve.Tools.Api.Database.Models;

namespace GoSolve.Dummy.Review.Data.Models;

public class Review : BaseEntity<long>
{
    public long BookId { get; set; }
    public string Author { get; set; }
    public int Rating { get; set; }
    public string Comment { get; set; }
}

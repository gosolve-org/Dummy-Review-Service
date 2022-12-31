using GoSolve.Tools.Common.Database.Models;
using GoSolve.Tools.Common.Database.Seeding.Interfaces;

namespace GoSolve.Dummy.Review.Data.Seeders.TestDataSeeders;

public class ReviewTestDataSeeder : ITestDataSeeder
{
    public IEnumerable<TimestampedEntity> BuildData()
    {
        return new Models.Review[]
        {
            new Models.Review
            {
                Id = 1,
                BookId = 1,
                Author = "John Smith",
                Rating = 3,
                Comment = "I enjoyed the story, but I found the ending to be a bit disappointing.",
                AuthorTypeId = 3
            },
            new Models.Review
            {
                Id = 2,
                BookId = 1,
                Author = "Jane Doe",
                Rating = 5,
                Comment = "I loved this book! The plot was engaging and I couldn't put it down. Highly recommend.",
                AuthorTypeId = 2
            },
            new Models.Review
            {
                Id = 3,
                BookId = 2,
                Author = "John Smith",
                Rating = 4,
                Comment = "This was a very informative book about the history of the Roman Empire. I learned a lot from reading it.",
                AuthorTypeId = 3
            },
            new Models.Review
            {
                Id = 4,
                BookId = 2,
                Author = "Samantha Williams",
                Rating = 3,
                Comment = "I found the book to be a bit dry and repetitive at times, but overall I did learn a lot.",
                AuthorTypeId = 1
            },
            new Models.Review
            {
                Id = 5,
                BookId = 3,
                Author = "Michael Thompson",
                Rating = 5,
                Comment = "This was a great mystery book! I was hooked from the very beginning and couldn't wait to find out who the culprit was.",
                AuthorTypeId = 1
            },
            new Models.Review
            {
                Id = 6,
                BookId = 3,
                Author = "Emily Davis",
                Rating = 4,
                Comment = "I enjoyed this book, but I found some of the clues to be a bit too obvious. Still a good read though.",
                AuthorTypeId = 1
            },
            new Models.Review
            {
                Id = 7,
                BookId = 4,
                Author = "David Smith",
                Rating = 2,
                Comment = "I didn't really enjoy this book. The romance was overly sappy and I found the plot to be predictable.",
                AuthorTypeId = 1
            },
            new Models.Review
            {
                Id = 8,
                BookId = 4,
                Author = "Emily Davis",
                Rating = 4,
                Comment = "I thought this was a sweet love story. The writing was beautiful and I enjoyed the characters.",
                AuthorTypeId = 1
            },
            new Models.Review
            {
                Id = 9,
                BookId = 5,
                Author = "John Smith",
                Rating = 5,
                Comment = "I absolutely loved this science fiction book! The world-building was excellent and the plot kept me on the edge of my seat.",
                AuthorTypeId = 3
            },
            new Models.Review
            {
                Id = 10,
                BookId = 5,
                Author = "Samantha Thompson",
                Rating = 4,
                Comment = "This was a great sci-fi book with an interesting plot and well-developed characters. The only thing I didn't like was the ending, which I thought was a bit rushed.",
                AuthorTypeId = 1
            }
        };
    }
}

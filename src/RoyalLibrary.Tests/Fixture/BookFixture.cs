using RoyalLibrary.Models;

namespace RoyalLibrary.Tests.Fixture;

public class BookFixture
{
    protected Book CreateBookForTest()
    {
        Book book = new()
        {
            book_id = 1,
            first_name = "Robert",
            last_name = "Martin",
            title = "Clean Code",
            total_copies = 5,
            copies_in_use = 3,
            isbn = "1234",
            type = "Printed",
        };

        return book;
    }

    protected IQueryable<Book> CreateBookListForTest()
    {
        var books = new List<Book>
        {
            new() { book_id = 1, title = "Book 1", first_name = "First Name", last_name = "Last Name" },
            new() { book_id = 2, title = "Book 2", first_name = "First Name", last_name = "Last Name" },
            new() { book_id = 3, title = "Book 3", first_name = "First Name", last_name = "Last Name" }
        }.AsQueryable();

        return books;
    }
}
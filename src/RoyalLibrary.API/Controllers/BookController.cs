using Microsoft.AspNetCore.Mvc;
using RoyalLibrary.Models;
using RoyalLibrary.Models.Handler;
using RoyalLibrary.Services.Interfaces;

namespace RoyalLibrary.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class BookController : ControllerBase
{
    private readonly IBookService _bookService;
    private readonly ILogger<BookController> _logger;

    public BookController(IBookService bookService, ILogger<BookController> logger)
    {
        _bookService = bookService;
        _bookService.BooksRetrieved += OnBooksRetrieved;
        _logger = logger;
    }

    [HttpGet]
    [ProducesResponseType(typeof(List<Book>), 200)]
    [ProducesResponseType(404)]
    public async Task<ActionResult> Get()
    {
        List<Book> data = await _bookService.List();

        _bookService.OnBooksRetrieved(new BooksRetrievedEventArgs(data));

        return data is null || data.Count == 0 ? NotFound() : new JsonResult(new { data });
    }

    [HttpGet("search")]
    [ProducesResponseType(typeof(List<Book>), 200)]
    [ProducesResponseType(404)]
    public async Task<ActionResult> Search(string searchType, string searchTerm)
    {
        List<Book> data = await _bookService.List();

        if (data == null || !data.Any())
        {
            return NotFound();
        }

        Dictionary<string, Func<Book, bool>> searchPredicates = new Dictionary<string, Func<Book, bool>>
        {
            ["author"] = b => b.first_name?.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) == true || b.last_name?.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) == true,

            ["isbn"] = b => b.isbn?.StartsWith(searchTerm, StringComparison.OrdinalIgnoreCase) == true,

            ["title"] = b => b.title?.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) == true
        };

        if (searchPredicates.TryGetValue(searchType, out Func<Book, bool>? predicate))
        {
            data = data.Where(predicate).ToList();
        }

        _bookService.OnBooksRetrieved(new BooksRetrievedEventArgs(data));

        return Ok(new { data });
    }

    private void OnBooksRetrieved(object sender, BooksRetrievedEventArgs events)
    {
        _logger.LogInformation($"Number of books retrieved: {events.Books.Count}");
    }
}
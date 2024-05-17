using Microsoft.AspNetCore.Mvc;
using RoyalLibrary.Models;
using RoyalLibrary.Services.Interfaces;

namespace RoyalLibrary.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class BookController(IBookService bookService) : ControllerBase
{
    private readonly IBookService _bookService = bookService;

    [HttpGet]
    [ProducesResponseType(typeof(List<Book>), 200)]
    [ProducesResponseType(404)]
    public async Task<ActionResult> Get()
    {
        List<Book> data = await _bookService.List();
        return data is null || data.Count == 0 ? NotFound() : new JsonResult(new { data });
    }

    [HttpGet]
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
            ["author"] = b =>
                b.first_name?.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) == true
                || b.last_name?.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) == true,

            ["isbn"] = b => b.isbn?.StartsWith(searchTerm, StringComparison.OrdinalIgnoreCase) == true,

            ["title"] = b => b.title?.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) == true
        };


        if (searchPredicates.TryGetValue(searchType, out Func<Book, bool>? predicate))
        {
            data = data.Where(predicate).ToList();
        }

        return Ok(new { data });
    }
}

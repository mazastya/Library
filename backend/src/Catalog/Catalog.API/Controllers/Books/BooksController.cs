using Catalog.Catalog.API.DTOs.Books;
using Catalog.Catalog.Application.Books;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Catalog.API.Controllers.Books;

[ApiController]
[Route("api/books")]
[Produces("application/json")]
public class BooksController(BookService bookService) : ControllerBase
{
    private readonly BookService _bookService = bookService;

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<BookResponse>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllBooks()
    {
        var books = await _bookService.GetBooksAsync();
        var response = books.Select(BookResponse.FromBookDomainModelToResponse).ToList();
        return Ok(response);
    }

    [HttpGet("{bookId:guid}")]
    [ProducesResponseType(typeof(BookResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetBook(Guid bookId)
    {
        var book = await _bookService.GetBookByIdAsync(bookId);
        var response = BookResponse.FromBookDomainModelToResponse(book);
        return Ok(response);
    }

    [HttpPost]
    [ProducesResponseType(typeof(Guid), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateBook(
        [FromBody] BookRequest bookRequest)
    {
        try
        {
            var book = await _bookService.CreateBookAsync(
                bookRequest.Title,
                bookRequest.Author,
                bookRequest.Status
            );
            return Ok(book);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("{bookId:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateBook(Guid bookId, [FromBody] BookRequest bookRequest)
    {
        try
        {
            await _bookService.UpdateBookAsync(bookId, bookRequest.Title, bookRequest.Author, bookRequest.Status);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpDelete("{bookId:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteBook(Guid bookId)
    {
        try
        {
            await _bookService.DeleteBookAsync(bookId);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}
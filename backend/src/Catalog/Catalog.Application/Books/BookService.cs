using Catalog.Catalog.Domain.Books;
using Catalog.Catalog.Domain.Contracts;

namespace Catalog.Catalog.Application.Books;

public class BookService(IBookRepository bookRepository)
{
    private readonly IBookRepository _bookRepository = bookRepository;

    public Book CreateBook(string title, string author, BookStatus status)
    {
        var book = new Book(title, author, status);
        return _bookRepository.CreateBook(book);
    }
}
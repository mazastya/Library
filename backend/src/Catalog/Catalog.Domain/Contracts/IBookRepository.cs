using Catalog.Catalog.Domain.Books;

namespace Catalog.Catalog.Domain.Contracts;

public interface IBookRepository
{
    public List<Book> GetBooks();
    public Book GetBookById(BookId bookId);
    public Book CreateBook(Book book);
    public Book UpdateBook(Book book);
    public void RemoveBook(Book book);
}
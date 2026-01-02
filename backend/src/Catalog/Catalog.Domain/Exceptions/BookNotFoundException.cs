using Catalog.Catalog.Domain.Books;

namespace Catalog.Catalog.Domain.Exceptions;

public class BookNotFoundException(BookId bookId) : DomainException($"Book with id - {bookId} not found")
{
}
namespace CatalogOld.CatalogOld.Domain.Exceptions;

public class BookWithIdNotFoundException(Guid bookId) : DomainException($"Book with id - {bookId} not found")
{
}

public class BookNotFoundException() : DomainException($"Book not found")
{
}
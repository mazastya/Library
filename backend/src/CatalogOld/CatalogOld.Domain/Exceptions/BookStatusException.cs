using CatalogOld.CatalogOld.Domain.Books;

namespace CatalogOld.CatalogOld.Domain.Exceptions;

public class BookStatusException(BookStatus status, Guid bookId)
    : DomainException($"Can't change the status to {status} of a book - {bookId}");
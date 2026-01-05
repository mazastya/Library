using Catalog.Catalog.Domain.Books;

namespace Catalog.Catalog.Domain.Exceptions;

public class BookStatusException(BookStatus status, Guid bookId)
    : DomainException($"Can't change the status to {status} of a book - {bookId}");
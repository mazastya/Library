using CatalogOld.Catalog.Domain.Books;

namespace CatalogOld.Catalog.API.DTOs.Books;

public record BookResponse(
    Guid BookId,
    string Title,
    string Author,
    BookStatus BookStatus)
{
    public static BookResponse FromBookDomainModelToResponse(Book book)
    {
        return new BookResponse(
            book.BookId,
            book.Title,
            book.Author,
            book.Status
        );
    }
}
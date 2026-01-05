using CatalogOld.Catalog.Domain.Books;
using CatalogOld.CatalogOld.Domain.Books;

namespace CatalogOld.CatalogOld.API.DTOs.Books;

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
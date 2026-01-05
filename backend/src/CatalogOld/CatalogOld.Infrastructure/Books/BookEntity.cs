using System.ComponentModel.DataAnnotations.Schema;
using CatalogOld.Catalog.Domain.Books;

namespace CatalogOld.Catalog.Infrastructure.Books;

[Table("Books")]
public class BookEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Title { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public BookStatus BookStatus { get; set; } = BookStatus.Available;

    public Book EntityToDomainModel()
    {
        var book = new Book(
            Title,
            Author,
            BookStatus
        );

        return book;
    }

    public static BookEntity DomainBookModelToEntity(Book book)
    {
        return new BookEntity
        {
            Id = book.BookId,
            Title = book.Title,
            Author = book.Author,
            BookStatus = book.Status
        };
    }
}
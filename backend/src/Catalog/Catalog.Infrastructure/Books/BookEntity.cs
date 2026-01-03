using System.ComponentModel.DataAnnotations.Schema;
using Catalog.Catalog.Domain.Books;

namespace Catalog.Catalog.Infrastructure.Books;

[Table("Books")]
public class BookEntity
{
    public BookId Id { get; init; } = BookId.New();
    public string Title { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public BookStatus BookStatus { get; set; } = BookStatus.Available;

    public Book EntityToDomainModel(BookEntity bookEntity)
    {
        return new Book
        {
            BookId = bookEntity.Id,
            Title = bookEntity.Title,
            Author = bookEntity.Author,
            Status = bookEntity.BookStatus,
        };
    }
}
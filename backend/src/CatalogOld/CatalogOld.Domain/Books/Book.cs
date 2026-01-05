using CatalogOld.Catalog.Domain.Books;

namespace CatalogOld.CatalogOld.Domain.Books;

public class Book(string title, string author)
{
    public Book() : this(null!, null!)
    {
    }

    public Guid BookId { get; init; } = Guid.NewGuid();
    public string Title { get; init; } = title;
    public string Author { get; init; } = author;
    public BookStatus Status { get; set; } = BookStatus.Available;
}
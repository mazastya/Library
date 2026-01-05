namespace CatalogOld.Catalog.Domain.Books;

public class Book(string title, string author, BookStatus? status)
{
    public Book() : this(null!, null!, null)
    {
    }

    public Guid BookId { get; init; } =  Guid.NewGuid();
    public string Title { get; init; } = title;
    public string Author { get; init; } = author;
    public BookStatus Status { get; set; } = BookStatus.Available;
}
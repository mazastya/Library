namespace Catalog.Catalog.Domain.Books;

public class Book(string title, string author, BookStatus? status)
{
    public BookId BookId { get; init; } = BookId.New();
    public string Title { get; init; } = title;
    public string Author { get; init; } = author;
    public BookStatus Status { get; set; } = BookStatus.Available;
}
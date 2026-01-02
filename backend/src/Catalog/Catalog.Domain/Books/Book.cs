namespace Catalog.Catalog.Domain.Books;

public class Book(string title, string? author, BookStatus status)
{
    public BookId BookId { get; init; } = new BookId();
    public string Title { get; init; } = title;
    public string? Author { get; init; } = author;
    public BookStatus Status { get; private set; }
}
namespace Catalog.Catalog.Domain.Books;

public interface IBookRepository
{
    public Task<Book?> GetBookByIdAsync(BookId bookId);
    public Task<List<Book>> GetBooksAsync();
    public Task AddAsync(Book book);
    public Task SaveAsync();
    public Task UpdateAsync(string? title, string? author, BookStatus? status);
    public Task RemoveAsync(Book book);
}
using CatalogOld.CatalogOld.Domain.Books;

namespace CatalogOld.Catalog.Domain.Books;

public interface IBookRepository
{
    public Task<Book?> GetBookByIdAsync(Guid bookId);
    public Task<List<Book>> GetBooksAsync();
    public Task AddAsync(Book book);
    public Task SaveAsync();
    public Task UpdateAsync(Book book);
    public Task DeleteAsync(Guid book);
}
using Catalog.Catalog.Domain.Books;
using Catalog.Catalog.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Catalog.Infrastructure.Books;

public class BookRepository(CatalogDbContext dbContext) : IBookRepository
{
    private readonly CatalogDbContext _dbContext = dbContext;

    public async Task<Book?> GetBookByIdAsync(BookId bookId)
    {
        var entity = await _dbContext.Books.FirstOrDefaultAsync(b => b.Id == bookId);
        return entity?.EntityToDomainModel(entity);
    }

    public Task<List<Book>> GetBooksAsync()
    {
        throw new NotImplementedException();
    }

    public Task AddAsync(Book book)
    {
        throw new NotImplementedException();
    }

    public Task SaveAsync()
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(string? title, string? author, BookStatus? status)
    {
        throw new NotImplementedException();
    }

    public Task RemoveAsync(Book book)
    {
        throw new NotImplementedException();
    }
}
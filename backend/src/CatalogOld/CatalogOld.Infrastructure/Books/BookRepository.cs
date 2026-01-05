using CatalogOld.Catalog.Domain.Books;
using CatalogOld.Catalog.Domain.Exceptions;
using CatalogOld.Catalog.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CatalogOld.Catalog.Infrastructure.Books;

public class BookRepository(CatalogDbContext dbContext) : IBookRepository
{
    private readonly CatalogDbContext _dbContext = dbContext;

    public async Task<Book?> GetBookByIdAsync(Guid bookId)
    {
        var bookEntity = await _dbContext.Books.FirstOrDefaultAsync(b => b.Id == bookId);
        return bookEntity?.EntityToDomainModel();
    }

    public async Task<List<Book>> GetBooksAsync()
    {
        var bookEntities = await _dbContext.Books.OrderBy(b => b.Title).ToListAsync();
        return bookEntities.Select(b => b.EntityToDomainModel()).ToList();
    }

    public async Task AddAsync(Book book)
    {
        var bookEntity = BookEntity.DomainBookModelToEntity(book);
        await _dbContext.Books.AddAsync(bookEntity);
    }

    public async Task SaveAsync()
    {
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Book book)
    {
        var bookEntity = await _dbContext.Books.FirstOrDefaultAsync(b => b.Id == book.BookId);
        if (bookEntity == null)
        {
            throw new BookNotFoundException();
        }

        bookEntity.Id = book.BookId;
        bookEntity.Title = book.Title;
        bookEntity.Author = book.Author;
        bookEntity.BookStatus = book.Status;
        _dbContext.Update(bookEntity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid bookId)
    {
        var bookEntity = await _dbContext.Books.FirstOrDefaultAsync(b => b.Id == bookId);
        if (bookEntity != null)
            _dbContext.Books.Remove(bookEntity);
    }
}
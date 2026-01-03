using Catalog.Catalog.Domain.Books;
using Catalog.Catalog.Domain.Exceptions;

namespace Catalog.Catalog.Application.Books;

public class BookService(IBookRepository bookRepository)
{
    private readonly IBookRepository _bookRepository = bookRepository;

    public async Task<Book> GetBookByIdAsync(BookId bookId) =>
        await _bookRepository.GetBookByIdAsync(bookId) ?? throw new BookWithIdNotFoundException(bookId);

    public async Task<List<Book>> GetBooksAsync() => await _bookRepository.GetBooksAsync();

    public async Task CreateBookAsync(string title, string author, BookStatus? status)
    {
        var book = new Book(title, author, status);
        await _bookRepository.AddAsync(book);
        await _bookRepository.SaveAsync();
    }

    public async Task UpdateBookAsync(BookId bookId, string? title, string? author, BookStatus? status)
    {
        var book = await _bookRepository.GetBookByIdAsync(bookId) ?? throw new BookWithIdNotFoundException(bookId);
        await _bookRepository.UpdateAsync(book);
        await _bookRepository.SaveAsync();
    }

    public async Task DeleteBookAsync(BookId bookId)
    {
        var book = await _bookRepository.GetBookByIdAsync(bookId) ?? throw new BookWithIdNotFoundException(bookId);
        await _bookRepository.DeleteAsync(book);
        await _bookRepository.SaveAsync();
    }

    public async Task MarkBookAsReservedAsync(BookId bookId)
    {
        var book = await _bookRepository.GetBookByIdAsync(bookId) ?? throw new BookWithIdNotFoundException(bookId);

        if (book.Status != BookStatus.Available)
            throw new BookStatusException(BookStatus.Reserved, bookId);

        book.Status = BookStatus.Reserved;
        await _bookRepository.UpdateAsync(book);
        await _bookRepository.SaveAsync();
    }

    // public Task MarkAsReservedAsync(BookId bookId);
    // public Task MarkAsCheckedOutAsync(BookId bookId);
    // public Task MarkAsReferenceOnlyAsync(BookId bookId);
    // public Task MarkAsUnavailableAsync(BookId bookId);
}
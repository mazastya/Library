namespace CatalogOld.Catalog.Domain.Books;

public readonly record struct BookId
    (Guid IdValue)
{
    public static BookId New() => new BookId(Guid.NewGuid());
    
}
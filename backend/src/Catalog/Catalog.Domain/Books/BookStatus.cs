namespace Catalog.Catalog.Domain.Books;

public enum BookStatus
{
    Available,
    Unavailable,
    ReferenceOnly,
    CheckedOut,
    Reserved
}
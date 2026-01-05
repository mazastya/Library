using System.ComponentModel.DataAnnotations;
using CatalogOld.Catalog.Domain.Books;
using CatalogOld.CatalogOld.Domain.Books;

namespace CatalogOld.CatalogOld.API.DTOs.Books;

public record BookRequest(
    [Required]
    [StringLength(100)]
    string Title,
    [Required]
    [StringLength(100)]
    string Author,
    BookStatus Status);
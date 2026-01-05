using System.ComponentModel.DataAnnotations;
using CatalogOld.Catalog.Domain.Books;

namespace CatalogOld.Catalog.API.DTOs.Books;

public record BookRequest(
    [Required]
    [StringLength(100)]
    string Title,
    [Required]
    [StringLength(100)]
    string Author,
    BookStatus Status);
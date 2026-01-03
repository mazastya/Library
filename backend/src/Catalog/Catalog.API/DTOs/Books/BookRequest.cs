using System.ComponentModel.DataAnnotations;
using Catalog.Catalog.Domain.Books;

namespace Catalog.Catalog.API.DTOs.Books;

public record BookRequest(
    [Required]
    [StringLength(100)]
    string Title,
    [Required]
    [StringLength(100)]
    string Author,
    BookStatus Status);
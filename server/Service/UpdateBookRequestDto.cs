using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace API;

public class UpdateBookRequestDto
{
    [NotNull][MinLength(1)]public string BookIdForLookup { get; set; }
    public string? NewBookTitle { get; set; }
    public string? NewAuthorId { get; set; }
}
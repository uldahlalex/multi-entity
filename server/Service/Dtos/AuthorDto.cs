using Facet;
using Infra.Entities;

namespace Service.Dtos;

[Facet(typeof(Author), nameof(Author.Books))]
public partial class AuthorDto
{
    public List<BookDto> Books { get; set; }
}
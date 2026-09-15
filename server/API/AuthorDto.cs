using Facet;
using Infra.Entities;

namespace API;

[Facet(typeof(Author), nameof(Author.Books))]
public partial class AuthorDto
{
    public List<BookDto> Books { get; set; }
}
using Facet;
using Infra.Entities;

namespace API;

[Facet(typeof(Book), nameof(Book.Author))]
public partial class BookDto;
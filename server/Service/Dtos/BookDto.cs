using Facet;
using Infra.Entities;

namespace Service.Dtos;

[Facet(typeof(Book), nameof(Book.Author))]
public partial class BookDto;
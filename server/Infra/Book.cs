
using LinqToDB.Mapping;

namespace Infra;

public class Book
{
    [PrimaryKey]public string Id { get; set; }
    [Column]public string Title { get; set; }
    [Column]public string AuthorId { get; set; }
    [Association(ThisKey = nameof(AuthorId), OtherKey = nameof(Author.AuthorId))]
    public Author Author { get; set; }
}
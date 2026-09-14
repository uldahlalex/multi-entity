using LinqToDB.Mapping;

namespace Infra;

public class Author
{
    [PrimaryKey]public string AuthorId { get; set; }
    [Column]public string AuthorName { get; set; }
}

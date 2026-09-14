
using LinqToDB.Mapping;

namespace Infra;

public class Book
{
    [PrimaryKey]public string Id { get; set; }
    [Column]public string Title { get; set; }
}
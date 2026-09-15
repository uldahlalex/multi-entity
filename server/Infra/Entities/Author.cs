using LinqToDB.Mapping;

namespace Infra.Entities;

public class Author
{
  
    
    [PrimaryKey] public string AuthorId { get; set; }
    [Column] public string AuthorName { get; set; }

    [Association(ThisKey = nameof(AuthorId), OtherKey = nameof(Book.AuthorId))]
    public List<Book> Books { get; set; }

    public int NumberOfBooksWritten { get; set; }
}
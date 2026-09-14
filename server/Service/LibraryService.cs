using Infra;
using LinqToDB;

namespace Service;

public class LibraryService(MyDatabaseConnection db)
{

    public void Create(string title)
    {
        db.Insert(new Book()
        {
            Id = Guid.NewGuid().ToString(),
            Title = title
        });
    }

    public List<Book> GetAll()
    {
       return db.Books.ToList();
    }

    public void Update()
    {
        throw new NotImplementedException();
    }

    public void Delete()
    {
        throw new NotImplementedException();
    }
}
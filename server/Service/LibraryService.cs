using Infra;

namespace Service;

public class LibraryService(MyDatabaseConnection db)
{

    public void Create(string title)
    {
        throw new NotImplementedException();
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
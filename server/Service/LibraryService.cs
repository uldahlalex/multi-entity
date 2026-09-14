using System.ComponentModel.DataAnnotations;
using API;
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

    public void Update(UpdateBookRequestDto dto)
    {
        var book = db.Books.FirstOrDefault(b => b.Id == dto.BookIdForLookup) ??
                   throw new ValidationException("that book didnt exist");
        if(dto.NewBookTitle!=null)
            book.Title = dto.NewBookTitle;
        db.Update(book);
    }

    public void Delete(string bookId)
    {
        var book = db.Books.FirstOrDefault(b => b.Id == bookId) ??
                   throw new ValidationException("that book didnt exist");
        db.Delete(book);
    }
}
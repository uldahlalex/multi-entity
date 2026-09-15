using System.ComponentModel.DataAnnotations;
using Infra;
using Infra.Entities;
using LinqToDB;
using Service.Dtos;

namespace Service;

public class LibraryService(MyDatabaseConnection db)
{
    public void Create(CreateBookRequestDto dto)
    {
        db.Insert(new Book
        {
            Id = Guid.NewGuid().ToString(),
            Title = dto.Title,
            AuthorId = dto.AuthorId
        });
    }

    public List<Book> GetAll()
    {
        return db.Books.LoadWith(b => b.Author).ToList();
    }

    public void Update(UpdateBookRequestDto dto)
    {
        var book = db.Books.FirstOrDefault(b => b.Id == dto.BookIdForLookup) ??
                   throw new ValidationException("that book didnt exist");
        _ = db.Authors.FirstOrDefault(a => a.AuthorId == dto.NewAuthorId) ??
            throw new ValidationException("The author ID you are trying to assign to the book doesnt exist");
        if (dto.NewBookTitle != null)
            book.Title = dto.NewBookTitle;
        if (dto.NewAuthorId != null)
            book.AuthorId = dto.NewAuthorId;
        db.Update(book);
    }

    public void Delete(string bookId)
    {
        var book = db.Books.FirstOrDefault(b => b.Id == bookId) ??
                   throw new ValidationException("that book didnt exist");
        db.Delete(book);
    }

    public void DeleteAuthor(string authorId)
    {
        using (var transaction = db.BeginTransaction())
        {
            var author = db.Authors.FirstOrDefault(a => a.AuthorId == authorId) ??
                         throw new ValidationException("author did not exist");
            db.Books.Where(b => b.AuthorId == author.AuthorId).Delete();
            db.Delete(author);
            transaction.Commit();
        }
    }
}
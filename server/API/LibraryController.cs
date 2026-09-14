using Infra;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace API;

public class LibraryController(LibraryService service) : ControllerBase
{
    [HttpGet(nameof(GetBooks))]
    public List<Book> GetBooks()
    {
        return service.GetAll();
    }
    [HttpPost(nameof(CreateBook))]
    public void CreateBook(CreateBookRequestDto dto)
    {
         service.Create(dto);
    }
     [HttpPut(nameof(UpdateBook))]
    public void UpdateBook(UpdateBookRequestDto dto)
    {
        service.Update(dto);
    }
[HttpDelete(nameof(DeleteBook))]
    public void DeleteBook(string bookId)
    {
        service.Delete(bookId);
    }
}
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
    public void CreateBook(string title)
    {
         service.Create(title);
    }
     [HttpPut(nameof(UpdateBook))]
    public void UpdateBook()
    {
        service.Update();
    }
[HttpDelete(nameof(DeleteBook))]
    public void DeleteBook()
    {
        service.Delete();
    }
}
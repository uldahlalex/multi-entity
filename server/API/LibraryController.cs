using Infra;
using Infra.Entities;
using LinqToDB;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace API;

public class LibraryController(LibraryService service, MyDatabaseConnection dbc) : ControllerBase
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

    [HttpGet(nameof(GetUsers))]
    public List<UserResponseDto> GetUsers()
    {
        return new List<User>
        {
            new()
            {
                PasswordHash = "sajdlsajdlkas",
                Salt = "alkdsækjdsa",
                Username = "Bob"
            }
        }.Select(u => new UserResponseDto
        {
            Username = u.Username
        }).ToList();
    }

    [HttpGet(nameof(GetAuthors))]
    public List<AuthorDto> GetAuthors()
    {
        //Validering

        //Query + projection
        var listOfAuthors = dbc
            .Authors
            .LoadWith(a => a.Books)
            .Select(a => new AuthorDto(a)
            {
                Books = a.Books.Select(b => new BookDto(b)).ToList()
            })
            .ToList();

        return listOfAuthors;
    }
}
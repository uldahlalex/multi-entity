using System.ComponentModel.DataAnnotations;
using Infra;
using Infra.Entities;
using LinqToDB;
using Microsoft.AspNetCore.Mvc;
using Service;
using Service.Dtos;

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
    public List<UserResponseDto> GetUsers(int count)
    {
        if (count < 0)
            throw new ValidationException("Count cannot be less than 0");
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
    public List<Service.Dtos.AuthorDto> GetAuthors()
    {
        //Validering

        //Query + projection
        var listOfAuthors = dbc
            .Authors
            .LoadWith(a => a.Books)
            .Select(a => new Service.Dtos.AuthorDto(a)
            {
                Books = a.Books.Select(b => new Service.Dtos.BookDto(b)).ToList()
            })
            .ToList();

        return listOfAuthors;
    }
}
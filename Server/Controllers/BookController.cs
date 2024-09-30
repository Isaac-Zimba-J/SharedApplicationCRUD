using Microsoft.AspNetCore.Mvc;
using Shared.Models;
using Shared.Services;

namespace Server.Controllers;

[ApiController]
[Route("[controller]")]
public class BookController(IBookService service) : Controller
{
    // GetAll Book
    [HttpGet]
    public async Task<ActionResult<ServiceResponse<List<Book>>>> GetAll()
    {
        return await service.GetAllBooks();
    }
    
    // GetBookById
    [HttpGet("{id}")]
    public async Task<ActionResult<ServiceResponse<Book>>> GetById(int id)
    {
        return await service.GetBookById(id);
    }
    
    // Add book
    [HttpPost]
    public async Task<ActionResult<ServiceResponse<Book>>> AddBook(Book book)
    {
        return await service.AddBook(book);
    }
    
    // Delete book
    [HttpDelete("{id}")]
    public async Task<ActionResult<ServiceResponse<Book>>> DeleteBook(int id)
    {
        return await service.DeleteBook(id);
    }
    
    //edit book
    [HttpPut]
    public async Task<ActionResult<ServiceResponse<Book>>> EditBook(Book updateBook)
    {
        return await service.UpdateBook(updateBook);
    }
    
    
    //search book
    [HttpPost("Search")]
    public async Task<ActionResult<ServiceResponse<Book>>> SearchBook([FromBody] string searchTerm)
    {
        return await service.SearchBook(searchTerm);
    }
    
}
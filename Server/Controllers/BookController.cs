using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.DataTransferObjects;
using Shared.Models;
using Shared.Services;

namespace Server.Controllers;

[ApiController]
[Route("[controller]")]
// [Authorize("Admin, ")]
public class BookController(IBookService service) : Controller
{
    // GetAll Book
    [HttpGet]
    public async Task<ActionResult<ServiceResponse<List<BookDto>>>> GetAll()
    {
        return await service.GetAllBooks();
    }
    
    // GetBookById
    [HttpGet("{id}")]
    [AllowAnonymous]
    public async Task<ActionResult<ServiceResponse<BookDto>>> GetById(int id)
    {
        return await service.GetBookById(id);
    }
    
    // Add book
    [HttpPost]
    public async Task<ActionResult<ServiceResponse<BookDto>>> AddBook(BookDto book)
    {
        return await service.AddBook(book);
    }
    
    // Delete book
    [HttpDelete("{id}")]
    public async Task<ActionResult<ServiceResponse<BookDto>>> DeleteBook(int id)
    {
        return await service.DeleteBook(id);
    }
    
    //edit book
    [HttpPut]
    public async Task<ActionResult<ServiceResponse<BookDto>>> EditBook(BookDto updateBook)
    {
        return await service.UpdateBook(updateBook);
    }
    //upload book
    [HttpPost("upload"), DisableRequestSizeLimit]
    public async Task<ActionResult<FileUpload>> Upload([FromForm]FileUpload book)
    {
        var response = await service.UplaodFile(book);
        if (response.Success)
        {
            return Ok(response);
        }
        return BadRequest(response);
    }
    
    //download book
    [HttpGet("download/{fileName}")]
    public async Task<ActionResult<ServiceResponse<string>>> Download(string fileName)
    {
        var response = await service.DownloadFile(fileName);
        if (response.Success)
        {
            return Ok(response);
        }
        return BadRequest(response);
    }

    
}
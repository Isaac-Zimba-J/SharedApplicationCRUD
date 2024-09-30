using Microsoft.AspNetCore.Mvc;
using Shared.Models;
using Shared.Services;

namespace Server.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthorController(IAuthorService service) : Controller
{
    // GETALL AUTHORS
    [HttpGet]
    public async Task<ActionResult<ServiceResponse<List<Author>>>> GetAll()
    {
        return await service.GetAllAuthors();
    }
    
    // GET AUTHOR BY ID
    [HttpGet("{id}")]
    public async Task<ActionResult<ServiceResponse<Author>>> GetById(int id)
    {
        return await service.GetAuthorById(id);
    }
    
    // ADD AUTHOR
    [HttpPost]
    public async Task<ActionResult<ServiceResponse<Author>>> AddAuthor(Author author)
    {
        return await service.AddAuthor(author);
    }
    
    // DELETE AUTHOR
    [HttpDelete("{id}")]
    public async Task<ActionResult<ServiceResponse<Author>>> DeleteAuthor(int id)
    {
        return await service.DeleteAuthor(id);
    }
    
    // EDIT AUTHOR
    [HttpPut]
    public async Task<ActionResult<ServiceResponse<Author>>> EditAuthor(Author updateAuthor)
    {
        return await service.UpdateAuthor(updateAuthor);
    }
    
    
}
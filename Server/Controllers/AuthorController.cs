using Microsoft.AspNetCore.Mvc;
using Shared.DataTransferObjects;
using Shared.Models;
using Shared.Services;

namespace Server.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthorController(IAuthorService service) : Controller
{
    // GETALL AUTHORS
    [HttpGet]
    public async Task<ActionResult<ServiceResponse<List<AuthorDto>>>> GetAll()
    {
        return await service.GetAllAuthors();
    }
    
    // GET AUTHOR BY ID
    [HttpGet("{id}")]
    public async Task<ActionResult<ServiceResponse<AuthorDto>>> GetById(int id)
    {
        return await service.GetAuthorById(id);
    }
    
    // ADD AUTHOR
    [HttpPost]
    public async Task<ActionResult<ServiceResponse<AuthorDto>>> AddAuthor(AuthorDto author)
    {
        return await service.AddAuthor(author);
    }
    
    // DELETE AUTHOR
    [HttpDelete("{id}")]
    public async Task<ActionResult<ServiceResponse<AuthorDto>>> DeleteAuthor(int id)
    {
        return await service.DeleteAuthor(id);
    }
    
    // EDIT AUTHOR
    [HttpPut]
    public async Task<ActionResult<ServiceResponse<AuthorDto>>> EditAuthor(AuthorDto updateAuthorDto)
    {
        return await service.UpdateAuthor(updateAuthorDto);
    }
    
    
}
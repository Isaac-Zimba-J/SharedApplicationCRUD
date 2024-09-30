using Server.Data;
using Shared.Models;
using Shared.Services;

namespace Server.Services;

public class AuthorService(LibraryDbContext context) : IAuthorService
{
    private readonly LibraryDbContext _context = context;
    
    public async Task<ServiceResponse<List<Author>>> GetAllAuthors()
    {
        // throw new NotImplementedException();
        ServiceResponse<List<Author>> response = new ServiceResponse<List<Author>>();
        response.Data = _context.Authors.ToList();
        return  response;
    }

    public async Task<ServiceResponse<Author>> GetAuthorById(int id)
    {
        // throw new NotImplementedException();
        ServiceResponse<Author> response = new ServiceResponse<Author>();
        response.Data = _context.Authors.FirstOrDefault(author => author.Id == id);
        return response;
    }

    public async Task<ServiceResponse<Author>> AddAuthor(Author newAuthor)
    {
        // throw new NotImplementedException();
        ServiceResponse<Author> response = new ServiceResponse<Author>();
        _context.AddAsync(newAuthor);
        _context.SaveChangesAsync();
        response.Data = newAuthor;
        return response;
    }
    

    public async Task<ServiceResponse<Author>> UpdateAuthor(Author updateAuthor)
    {
        // throw new NotImplementedException();
        ServiceResponse<Author> response = new ServiceResponse<Author>();
        Author author = _context.Authors.FirstOrDefault(author => author.Id == updateAuthor.Id);
        author.FirstName = updateAuthor.FirstName;
        author.LastName = updateAuthor.LastName;
        author.DOB = updateAuthor.DOB;
        await _context.SaveChangesAsync();
        response.Data = author;
        return response;
        

    }

    public async Task<ServiceResponse<Author>> DeleteAuthor(int id)
    {
        // throw new NotImplementedException();
        ServiceResponse<Author> response = new ServiceResponse<Author>();
        Author author = _context.Authors.FirstOrDefault(author => author.Id == id);
       _context.Authors.Remove(author);
        
        return response;
    }
}
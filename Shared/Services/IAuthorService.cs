using Shared.Models;

namespace Shared.Services;

public interface IAuthorService
{
    Task<ServiceResponse<List<Author>>> GetAllAuthors();
    Task<ServiceResponse<Author>> GetAuthorById(int id);
    Task<ServiceResponse<Author>> AddAuthor(Author newAuthor);
    Task<ServiceResponse<Author>> UpdateAuthor(Author updateAuthor);
    Task<ServiceResponse<Author>> DeleteAuthor(int id);
    

}
using Shared.DataTransferObjects;
using Shared.Models;

namespace Shared.Services;

public interface IAuthorService
{
    Task<ServiceResponse<List<AuthorDto>>> GetAllAuthors();
    Task<ServiceResponse<AuthorDto>> GetAuthorById(int id);
    Task<ServiceResponse<AuthorDto>> AddAuthor(AuthorDto newAuthor);
    Task<ServiceResponse<AuthorDto>> UpdateAuthor(AuthorDto updateAuthor);
    Task<ServiceResponse<AuthorDto>> DeleteAuthor(int id);
    

}
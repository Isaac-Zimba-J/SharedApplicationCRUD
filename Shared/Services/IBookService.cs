using Shared.Models;

namespace Shared.Services;

public interface IBookService
{
    Task<ServiceResponse<List<Book>>> GetAllBooks();
    Task<ServiceResponse<Book>> GetBookById(int Id);
    Task<ServiceResponse<Book>> AddBook(Book newBook);
    Task<ServiceResponse<Book>> UpdateBook(Book updateBook);
    Task<ServiceResponse<Book>> DeleteBook(int Id);
    Task<ServiceResponse<Book>> SearchBook(string query);
}
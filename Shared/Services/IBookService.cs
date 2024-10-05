using Microsoft.AspNetCore.Mvc;
using Shared.DataTransferObjects;
using Shared.Models;

namespace Shared.Services;

public interface IBookService
{
    Task<ServiceResponse<List<BookDto>>> GetAllBooks();
    Task<ServiceResponse<BookDto>> GetBookById(int Id);
    Task<ServiceResponse<BookDto>> AddBook(BookDto newBookDto);
    Task<ServiceResponse<BookDto>> UpdateBook(BookDto updateBookDto);
    Task<ServiceResponse<BookDto>> DeleteBook(int Id);
    Task<ServiceResponse<BookDto>> SearchBook(string query);
    Task<ServiceResponse<FileUpload>> UplaodFile([FromForm] FileUpload model);
    Task<ServiceResponse<string>> DownloadFile(string fileName);
}
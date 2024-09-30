using Server.Data;
using Shared.Models;
using Shared.Services;
using Shared.DataTransferObjects;

namespace Server.Services;

public class BookService(LibraryDbContext context) : IBookService
{
    private readonly LibraryDbContext _context = context;

    public async Task<ServiceResponse<List<BookDto>>> GetAllBooks()
    {
        // throw new NotImplementedException();
        // ServiceResponse<List<Book>> response = new ServiceResponse<List<Book>>();
        // response.Data = _context.Books.ToList();
        // return response;

        var response = new ServiceResponse<List<BookDto>>();
    }

    public async Task<ServiceResponse<Book>> GetBookById(int Id)
    {
        // throw new NotImplementedException();
        ServiceResponse<Book> response = new ServiceResponse<Book>();
        response.Data = _context.Books.FirstOrDefault(book => book.Id == Id);
        return response;
    }

    public async Task<ServiceResponse<Book>> AddBook(Book newBook)
    {
        // throw new NotImplementedException();
        ServiceResponse<Book> response = new ServiceResponse<Book>();
        await _context.Books.AddAsync(newBook);
        await _context.SaveChangesAsync();
        response.Data = newBook;
        return response;
    }

    public async Task<ServiceResponse<Book>> UpdateBook(Book updateBook)
    {
        // throw new NotImplementedException();
        ServiceResponse<Book> response = new ServiceResponse<Book>();
        Book book = _context.Books.FirstOrDefault(book => book.Id == updateBook.Id);
        book.BookTitle = updateBook.BookTitle;
        book.BookAuthors = updateBook.BookAuthors;
        book.Category = updateBook.Category;
        book.Status = updateBook.Status;
        book.NumberOfPages = updateBook.NumberOfPages;
        book.PublishDate = updateBook.PublishDate;
        book.ISBN = updateBook.ISBN;
        book.Description = updateBook.Description;
        book.ImageUrl = updateBook.ImageUrl;
        await _context.SaveChangesAsync();
        response.Data = book;
        return response;    
        
    }

    public async Task<ServiceResponse<Book>> DeleteBook(int Id)
    {
        // throw new NotImplementedException();
        ServiceResponse<Book> response = new ServiceResponse<Book>();
        Book book = _context.Books.FirstOrDefault(book => book.Id == Id);
        if(book != null)
        {
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
            response.Data = book;
        }
        else
        {
            response.Success = false;
            response.Message = "Book not found.";
        }
        return response;
    }

    public async Task<ServiceResponse<Book>> SearchBook(string query)
    {
        // throw new NotImplementedException();
        ServiceResponse<Book> response = new ServiceResponse<Book>();
        response.Data = _context.Books.FirstOrDefault(book => book.BookTitle.ToLower().Contains(query.ToLower()));
        return response;
        
    }
}
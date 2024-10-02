using Microsoft.EntityFrameworkCore;
using Server.Data;
using Shared.Models;
using Shared.Services;
using Shared.DataTransferObjects;
using Shared.Enums;

namespace Server.Services;

public class BookService(LibraryDbContext context) : IBookService
{
    private readonly LibraryDbContext _context = context;


    public async Task<ServiceResponse<List<BookDto>>> GetAllBooks()
    {
        var response = new ServiceResponse<List<BookDto>>();
        var books = await _context.Books.Include(b=>b.Authors).ToListAsync();

        if (books == null)
        {
            response.Success = false;
            response.Message = "No books found.";
            return response;
        }

        response.Data = books.Select(book => new BookDto
        {
            Id = book.Id,
            BookTitle = book.BookTitle,
            Status = (int)book.Status, // Convert enum to int
            Category = (int)book.Category, // Convert enum to int
            NumberOfPages = book.NumberOfPages,
            PublishDate = book.PublishDate.ToString("yyyy-MM-dd"), // Convert DateOnly to string
            ISBN = book.ISBN,
            Description = book.Description,
            ImageUrl = book.ImageUrl
        }).ToList();

        return response;
    }
    public async Task<ServiceResponse<BookDto>> GetBookById(int Id)
    {
        // throw new NotImplementedException();
        var response = new ServiceResponse<BookDto>();
        var book = await _context.Books.FindAsync(Id);
        if (book == null)
        {
            response.Success = false;
            response.Message = "Book bot found.";
            return response;
        }

        response.Data = new BookDto
        {
            Id = book.Id,
            BookTitle = book.BookTitle,
            Status = (int)book.Status, // Convert enum to int
            Category = (int)book.Category, // Convert enum to int
            NumberOfPages = book.NumberOfPages,
            PublishDate = book.PublishDate.ToString("yyyy-MM-dd"), // Convert DateOnly to string
            ISBN = book.ISBN,
            Description = book.Description,
            ImageUrl = book.ImageUrl
        };
        return response;
    }

    public async Task<ServiceResponse<BookDto>> AddBook(BookDto newBookDto)
    {
        // throw new NotImplementedException();
        var response = new ServiceResponse<BookDto>();
        var newBook = new Book
        {
            Id = newBookDto.Id,
            BookTitle = newBookDto.BookTitle,
            Status = (Status)newBookDto.Status, // Convert enum to int
            Category = (Category)newBookDto.Category, // Convert enum to int
            NumberOfPages = newBookDto.NumberOfPages,
            PublishDate = DateOnly.Parse(newBookDto.PublishDate), // Convert DateOnly to string
            ISBN = newBookDto.ISBN,
            Description = newBookDto.Description,
            ImageUrl = newBookDto.ImageUrl,
        };
        await _context.Books.AddAsync(newBook);
        await _context.SaveChangesAsync();
        response.Data = newBookDto;
        return response;
    }

    public async Task<ServiceResponse<BookDto>> UpdateBook(BookDto updateBookDto)
    {
        // throw new NotImplementedException();
        var response = new ServiceResponse<BookDto>();
        var book = await _context.Books.FindAsync(updateBookDto.Id);
        if (book == null)
        {
            response.Success = false;
            response.Message = "Book not found";
            return response;
        }
        book.BookTitle = updateBookDto.BookTitle;
        book.Status = (Status)updateBookDto.Status; // Convert int to enum
        book.Category = (Category)updateBookDto.Category; // Convert int to enum
        book.NumberOfPages = updateBookDto.NumberOfPages;
        book.PublishDate = DateOnly.Parse(updateBookDto.PublishDate); // Convert string to DateOnly
        book.ISBN = updateBookDto.ISBN;
        book.Description = updateBookDto.Description;
        book.ImageUrl = updateBookDto.ImageUrl;
        await _context.SaveChangesAsync();
        response.Data = updateBookDto;
        return response;
    }

    public async Task<ServiceResponse<BookDto>> DeleteBook(int Id)
    {
        // throw new NotImplementedException();
        var response = new ServiceResponse<BookDto>();
        var book = await _context.Books.FindAsync(Id);
        if (book == null)
        {
            response.Success = false;
            response.Message = "Book not found";
            return response;
        }
        response.Data = new BookDto()
        {
            Id = book.Id,
            BookTitle = book.BookTitle,
            Status = (int)book.Status, // Convert enum to int
            Category = (int)book.Category, // Convert enum to int
            NumberOfPages = book.NumberOfPages,
            PublishDate = book.PublishDate.ToString("yyyy-MM-dd"), // Convert DateOnly to string
            ISBN = book.ISBN,
            Description = book.Description,
            ImageUrl = book.ImageUrl,
        };
        return response;
    }

    public Task<ServiceResponse<BookDto>> SearchBook(string query)
    {
        throw new NotImplementedException();
    }
}
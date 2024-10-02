using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Server.Data;
using Shared.DataTransferObjects;
using Shared.Models;
using Shared.Services;

namespace Server.Services;

public class AuthorService : IAuthorService
{
    
    private readonly LibraryDbContext _context;
    private readonly IMapper _mapper;

    public AuthorService(LibraryDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper ;
    }
    
    public async Task<ServiceResponse<List<AuthorDto>>> GetAllAuthors()
    {
        // throw new NotImplementedException();
        var response = new ServiceResponse<List<AuthorDto>>();
        var authors = await _context.Authors.ToListAsync();
        response.Data = _mapper.Map<List<AuthorDto>>(authors);
        return response;

    }

    public async Task<ServiceResponse<AuthorDto>> GetAuthorById(int id)
    {
        var response = new ServiceResponse<AuthorDto>();
        var author = await _context.Authors.FirstOrDefaultAsync(a => a.Id == id);
        response.Data = _mapper.Map<AuthorDto>(author);
        return response;
    }


    public async Task<ServiceResponse<AuthorDto>> AddAuthor(AuthorDto newAuthorDto)
    {
        var response = new ServiceResponse<AuthorDto>();
        var newAuthor = _mapper.Map<Author>(newAuthorDto);
        await _context.AddAsync(newAuthor);
        await _context.SaveChangesAsync();
        response.Data = _mapper.Map<AuthorDto>(newAuthor);
        return response;

    }
    

    public async Task<ServiceResponse<AuthorDto>> UpdateAuthor(AuthorDto updateAuthorDto)
    {
        // throw new NotImplementedException();
        var response = new ServiceResponse<AuthorDto>();
        var author = await _context.Authors.FirstOrDefaultAsync(author => author.Id == updateAuthorDto.Id);
        if (author == null)
        {
            response.Success = false;
            response.Message = "Author not found.";
            return response;
        }
        else
        {
            _mapper.Map(updateAuthorDto, author);
            await _context.SaveChangesAsync();
            response.Data = _mapper.Map<AuthorDto>(author);
            return response;
        }
    }

    public async Task<ServiceResponse<AuthorDto>> DeleteAuthor(int id)
    {
        // throw new NotImplementedException();
        var response = new ServiceResponse<AuthorDto>();
        var author = await _context.Authors.FirstOrDefaultAsync(author => author.Id == id);
        if (author == null)
        {
            response.Success = false;
            response.Message = "Author not found.";
            return response;
        }
        else
        {
            _context.Authors.Remove(author);
            await _context.SaveChangesAsync();
            response.Data = _mapper.Map<AuthorDto>(author);
            return response;
        }

    }
}
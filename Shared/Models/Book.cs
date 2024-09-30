using Shared.Enums;
namespace Shared.Models;

public class Book
{
    public int Id { get; set; }
    public string BookTitle { get; set; }
    public Category Category { get; set; }
    public Status Status { get; set; }
    public int NumberOfPages { get; set; }
    public DateOnly PublishDate { get; set; }
    public string ISBN { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }
    public List<BookAuthor> BookAuthors { get; set; }
    
}
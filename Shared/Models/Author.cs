namespace Shared.Models;

public class Author
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateOnly DOB { get; set; }

    public List<Book> Books { get; set; }
}
namespace Shared.DataTransferObjects;

public class BookDto
{
    public int Id { get; set; }
    public string BookTitle { get; set; }
    public int Category { get; set; }
    public int Status { get; set; }
    public int NumberOfPages { get; set; }
    public string PublishDate { get; set; }
    public string ISBN { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }
    public List<AuthorDto> Authors { get; set; }
}
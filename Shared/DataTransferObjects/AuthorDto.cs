namespace Shared.DataTransferObjects;

public class AuthorDto
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Dob { get; set; }
    public List<int> BookIds { get; set; }
}
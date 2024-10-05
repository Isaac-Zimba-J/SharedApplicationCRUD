using Microsoft.AspNetCore.Http;

namespace Shared.Models;

public class FileUpload
{
    public IFormFile File { get; set; }
    
    public string Author { get; set; }
    
    public string Title { get; set; }
}
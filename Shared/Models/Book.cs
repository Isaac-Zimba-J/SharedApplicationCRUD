using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;
using Shared.DataTransferObjects;
using Shared.Enums;
namespace Shared.Models;

public class Book
{
    [Key]
    public int Id { get; set; }
    public string BookTitle { get; set; }
    public Category Category { get; set; }
    public Status Status { get; set; }
    public int NumberOfPages { get; set; }
    public DateOnly PublishDate { get; set; }
    public string ISBN { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }
    public List<Author> Authors { get; set; }
    // public int AuthId { get; set; }
    // [ForeignKey("AuthId")]
    // public Author Author { get; set; }
}
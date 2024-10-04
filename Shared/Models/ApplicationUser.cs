using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Shared.Models;

public class ApplicationUser : IdentityUser
{
    // [Key]
    [NotMapped]
    public string StudentId { get => Id; set { Id = value; } }
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
}
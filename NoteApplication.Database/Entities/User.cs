using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models;

public class User
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string UserName { get; set; }

    public byte[] PasswordHash { get; set; }

    public byte[] PasswordSalt { get; set; }

    public List<Category> Categories { get; set; } = new();

    public List<Note> Notes { get; set; } = new();
}
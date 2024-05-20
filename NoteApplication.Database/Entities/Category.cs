using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace DataAccess.Models;

public class Category
{
    [Key]
    public int Id { get; set; }

    [MaxLength(40)]
    public string Name { get; set; }

    public List<Note> Notes { get; set; } = new();

    [ForeignKey("User")]
    public int UserId { get; set; }

    public User User { get; set; }
}
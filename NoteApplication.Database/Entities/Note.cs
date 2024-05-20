using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace DataAccess.Models;

public class Note
{
    [Key]
    public int Id { get; set; }

    [MaxLength(40)]
    public string Title { get; set; }

    [MaxLength(400)]
    public string Text { get; set; }

    public string PhotoPath { get; set; }

    [Required]
    [ForeignKey("Category")]
    public int CategoryId { get; set; }

    public Category Category { get; set; }

    [ForeignKey("User")]
    public int UserId { get; set; }

    public User User { get; set; }
}
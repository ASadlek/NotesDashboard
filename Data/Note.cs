using System.ComponentModel.DataAnnotations;

namespace Notes.Data;

public class Note
{
    public int Id { get; set; }

    [Required(ErrorMessage = "First name is required")]
    [StringLength(20)]
    public string FirstName { get; set; }

    [Required(ErrorMessage = "Last name is required")]
    [StringLength(20)]
    public string LastName { get; set; }

    [Required(ErrorMessage = "Date is required")]
    public DateTime Date { get; set; }

    [Required(ErrorMessage = "Mood is required")]
    public string Mood { get; set; }

    [Required(ErrorMessage = "Message is required")]
    [StringLength(40)]
    public string Message { get; set; }
}
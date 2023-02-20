using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace StudentFiles.Models;

public class Student
{
    public int Id { get; set; }

    [StringLength(60, MinimumLength = 3)]
    [Required]
    public string? Name { get; set; }


    //[Display(Name = "Release Date")]
    //[DataType(DataType.Date)]
    //public DateTime ReleaseDate { get; set; }

    [DataType(DataType.Date)]
    public DateTime ReleaseDate { get; set; } = DateTime.Today;


    [Display(Name = "Admission")]
    public bool HasAdmissionLetter { get; set; }

    [Display(Name = "Scholarship")]
    public bool HasScholarshipLetter { get; set; }

    [Range(1, 4)]
    [Column(TypeName = "decimal(4, 1)")]
    public decimal GPA { get; set; }

    [Required]
    [RegularExpression("^[0-9]{8}$")]
    public string StudentId { get; set; }
}
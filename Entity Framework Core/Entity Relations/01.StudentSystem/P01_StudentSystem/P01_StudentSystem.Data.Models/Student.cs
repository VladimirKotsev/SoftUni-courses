namespace P01_StudentSystem.Data.Models;

using System.ComponentModel.DataAnnotations;

using P01_StudentSystem.Data.Common;

public class Student
{
    public Student()
    {
        this.StudentsCourses = new HashSet<StudentCourse>();
        this.Homeworks = new HashSet<Homework>();
    }

    [Key]
    public int StudentId { get; set; }

    [Required]
    [MaxLength(ValidationConstrants.StudentNameMaxLength)]
    public string Name { get; set; } = null!;

    [StringLength(ValidationConstrants.StudentPhoneNumberLength)]
    public string? PhoneNumber { get; set; }

    public DateTime RegisteredOn { get; set; }

    public DateTime? Birthday  { get; set; }

    public ICollection<StudentCourse> StudentsCourses { get; set; }

    public ICollection<Homework> Homeworks { get; set; }
}

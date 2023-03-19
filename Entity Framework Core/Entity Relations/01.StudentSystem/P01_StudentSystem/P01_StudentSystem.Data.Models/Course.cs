namespace P01_StudentSystem.Data.Models;

using System.ComponentModel.DataAnnotations;

using P01_StudentSystem.Data.Common;

public class Course
{
    public Course()
    {
        this.StudentsCourses = new HashSet<StudentCourse>();
        this.Resources = new HashSet<Resource>();
        this.Homeworks = new HashSet<Homework>();
    }

    [Key]
    public int CourseId { get; set; }

    [Required]
    [MaxLength(ValidationConstrants.CourseNameMaxLength)]
    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public decimal Price { get; set; }

    public ICollection<StudentCourse> StudentsCourses { get; set; }

    public ICollection<Resource> Resources { get; set; }

    public ICollection<Homework> Homeworks { get; set; }
}

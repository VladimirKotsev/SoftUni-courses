namespace P01_StudentSystem.Data.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using P01_StudentSystem.Data.Common;
using P01_StudentSystem.Data.Models.Enums;

public class Resource
{
    [Key]
    public int ResourceId { get; set; }

    [Required]
    [MaxLength(ValidationConstrants.ResourceNameMaxLength)]
    public string Name { get; set; } = null!;

    [Required]
    public string Url { get; set; } = null!;

    public ResourceType ResourceType { get; set; }

    [ForeignKey(nameof(Course))]
    public int CourseId { get; set; }
    public Course Course { get; set; } = null!;
}

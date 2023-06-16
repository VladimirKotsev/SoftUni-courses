namespace Library.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using Library.Common.Validations;
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(ValidationConstraints.Category.NameMaxLength)]
        public string Name { get; set; } = null!;

        public virtual ICollection<Book> Books { get; set; } = null!;
    }
}
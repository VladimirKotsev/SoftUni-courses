namespace Library.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Common.Validations;
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(ValidationConstraints.Book.TitleMaxLength)]
        public string Title { get; set; } = null!;

        [Required]
        [MaxLength(ValidationConstraints.Book.AuthorMaxLength)]
        public string Author { get; set; } = null!;

        [Required]
        [MaxLength(ValidationConstraints.Book.DescriptionMaxLength)]
        public string Description { get; set; } = null!;

        [Required]
        public string ImageUrl { get; set; } = null!;

        [Required]
        [Range(ValidationConstraints.Book.RatingMinValue, ValidationConstraints.Book.RatingMaxValue)]
        public decimal Rating { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [Required]
        [ForeignKey(nameof(CategoryId))]
        public virtual Category Category { get; set; } = null!;

        public virtual ICollection<IdentityUserBook> UsersBooks { get; set; } = null!;
    }
}

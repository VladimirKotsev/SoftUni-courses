namespace Library.Models.Library
{
    using System.ComponentModel.DataAnnotations;

    using Common.Validations;

    public class AddBookViewModel
    {
        [Required]
        [StringLength(ValidationConstraints.Book.TitleMaxLength, 
            MinimumLength = ValidationConstraints.Book.TitleMinLength)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(ValidationConstraints.Book.AuthorMaxLength, 
            MinimumLength = ValidationConstraints.Book.AuthorMinLength)]
        public string Author { get; set; } = null!;

        [Required]
        [StringLength(ValidationConstraints.Book.DescriptionMaxLength, 
            MinimumLength = ValidationConstraints.Book.DescriptionMinLength)]
        public string Description { get; set; } = null!;

        [Required(AllowEmptyStrings = false)]
        public string ImageUrl { get; set; } = null!;

        [Required]
        [Range(ValidationConstraints.Book.RatingMinValue, ValidationConstraints.Book.RatingMaxValue)]
        public decimal Rating { get; set; }

        public int CategoryId { get; set; }
        public ICollection<CategoryViewModel> Categories { get; set; } = new HashSet<CategoryViewModel>();
    }
}

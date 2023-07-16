namespace Homies.Models.Event
{
    using Microsoft.AspNetCore.Identity;

    using System.ComponentModel.DataAnnotations;

    using Common.Validations;
    public class AddEventViewModel
    {
        [Required]
        [StringLength(ValidationConstraints.Event.NameMaxLength,
            MinimumLength = ValidationConstraints.Event.NameMinLength)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(ValidationConstraints.Event.DescriptionMaxLength,
            MinimumLength = ValidationConstraints.Event.DescriptionMinLength)]
        public string Description { get; set; } = null!;

        public int TypeId { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public ICollection<TypeViewModel> Types { get; set; } = new List<TypeViewModel>();
    }
}

namespace Homies.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using Common.Validations;
    public class Type
    {
        public Type()
        {
            this.Events = new List<Event>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(ValidationConstraints.Type.NameMaxLength)]
        public string Name { get; set; } = null!;

        public virtual ICollection<Event> Events { get; set; } = null!;
    }
}

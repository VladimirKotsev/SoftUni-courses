namespace Library.Data.Models
{
    using Microsoft.AspNetCore.Identity;

    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class IdentityUserBook
    {
        [Required]
        public string CollectorId { get; set; }

        [ForeignKey(nameof(CollectorId))]
        public IdentityUser Collector { get; set; } = null!;

        [Required]
        public int BookId { get; set; }

        [ForeignKey(nameof(BookId))]
        public virtual Book Book { get; set; } = null!;
    }
}

//• CollectorId – a string, Primary Key, foreign key (required)
//• Collector – IdentityUser
//• BookId – an integer, Primary Key, foreign key (required)
//• Book – Book

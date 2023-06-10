namespace ChatApp.Models.Chat
{
    using System.ComponentModel.DataAnnotations;
    public class MessageViewModel
    {
        [Required]
        [MaxLength(255)]
        public string Message { get; set; } = null!;

        [Required]
        [MaxLength(50)]
        public string Sender { get; set; } = null!;
    }
}

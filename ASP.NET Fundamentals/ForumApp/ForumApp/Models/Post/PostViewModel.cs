namespace ForumApp.Models.Post
{
    using System.ComponentModel.DataAnnotations;
    public class PostViewModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string PostTitle { get; set; } = null!;

        [Required]
        [MaxLength(100)]
        public string PostDescription { get; set; } = null!;
    }
}

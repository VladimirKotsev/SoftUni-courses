namespace MusicHub.Data.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Album
{
    public Album()
    {
        this.Songs = new HashSet<Song>();
    }

    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(ValidationConstrants.albumNameMaxLength)]
    public string Name { get; set; } = null!;

    public DateTime ReleaseDate  { get; set; }

    //Judge might not like that!!!!
    public decimal Price 
    {
        get { return this.Songs.Sum(x => x.Price); }
    }

    [ForeignKey(nameof(Producer))]
    public int? ProducerId { get; set; }
    public Producer? Producer { get; set; }

    public ICollection<Song> Songs { get; set; }
}


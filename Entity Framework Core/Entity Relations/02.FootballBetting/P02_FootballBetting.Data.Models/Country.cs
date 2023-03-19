namespace P02_FootballBetting.Data.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using P02_FootballBetting.Data.Common;

public class Country
{
    public Country()
    {
        this.Towns = new HashSet<Town>();
    }

    [Key]
    public int CountryId { get; set; }

    [Required]
    [MaxLength(ValidationConstrants.CountryNameMaxLength)]
    public string Name { get; set; }

    public virtual ICollection<Town> Towns { get; set; }
}

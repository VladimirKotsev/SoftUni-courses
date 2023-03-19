namespace P02_FootballBetting.Data.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using P02_FootballBetting.Data.Common;

public class Team
{
    public Team()
    {
        this.HomeGames = new HashSet<Game>();
        this.AwayGames = new HashSet<Game>();
        this.Players = new HashSet<Player>();
    }

    [Key] // UNIQUE, PRIMARY KEY
    public int TeamId { get; set; }

    [Required] // NOT NULL
    [MaxLength(ValidationConstrants.TeamNameMaxLenght)]
    public string Name { get; set; }

    [MaxLength(ValidationConstrants.TeamLogoUrlMaxLength)]
    public string LogoUrl { get; set; }

    [Required]
    [MaxLength(ValidationConstrants.TeamInitialsMaxLength)]
    public string Initials { get; set; }

    public decimal Budget { get; set; }

    [ForeignKey(nameof(PrimaryKitColor))]
    public int PrimaryKitColorId { get; set; }
    public virtual Color PrimaryKitColor { get; set; }

    [ForeignKey(nameof(SecondaryKitColor))]
    public int SecondaryKitColorId { get; set; }
    public virtual Color SecondaryKitColor { get; set; }

    [ForeignKey(nameof(Town))]
    public int TownId { get; set; }
    public virtual Town Town { get; set; }

    [InverseProperty(nameof(Game.HomeTeam))]
    public virtual ICollection<Game> HomeGames { get; set; }

    [InverseProperty(nameof(Game.AwayTeam))]
    public virtual ICollection<Game> AwayGames { get; set; }

    public virtual ICollection<Player> Players { get; set; }

}

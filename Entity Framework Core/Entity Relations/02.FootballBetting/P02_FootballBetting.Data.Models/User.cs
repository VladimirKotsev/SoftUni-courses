namespace P02_FootballBetting.Data.Models;

using System.ComponentModel.DataAnnotations;

using P02_FootballBetting.Data.Common;
public class User
{
    public User()
    {
        this.Bets = new HashSet<Bet>();
    }

    [Key]
    public int UserId { get; set; }

    [Required]
    [MaxLength(ValidationConstrants.UserUsernameMaxLength)]
    public string Username { get; set; }

    [Required]
    [MaxLength(ValidationConstrants.UserPasswordMaxLenght)]
    public string Password { get; set; }

    [Required]
    [MaxLength(ValidationConstrants.UserEmailMaxLength)]
    public string Email { get; set; }

    [Required]
    [MaxLength(ValidationConstrants.UserNameMaxLength)]
    public string Name { get; set; }

    public decimal Balance { get; set; }

    public virtual ICollection<Bet> Bets { get; set; }
}

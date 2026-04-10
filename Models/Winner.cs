using System.ComponentModel.DataAnnotations;

namespace OOPAlgoQuizGame.Models
{
    public class Winner
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        public double Score { get; set; }

        [Required]
        public string Category { get; set; } = string.Empty;

        public DateTime DateAchieved { get; set; } = DateTime.UtcNow;
    }
}

using System.ComponentModel.DataAnnotations;

namespace OOPAlgoQuizGame.Models
{
    public class Question
    {
        public int Id { get; set; }

        [Required]
        public string QuestionText { get; set; } = string.Empty;

        [Required]
        public string OptionA { get; set; } = string.Empty;

        [Required]
        public string OptionB { get; set; } = string.Empty;

        [Required]
        public string OptionC { get; set; } = string.Empty;

        [Required]
        public string OptionD { get; set; } = string.Empty;

        /// <summary>Correct answer stored as "A", "B", "C", or "D".</summary>
        [Required]
        public string CorrectAnswer { get; set; } = string.Empty;

        [Required]
        public string Category { get; set; } = string.Empty;
    }
}

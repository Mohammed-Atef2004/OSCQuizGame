namespace OOPAlgoQuizGame.ViewModels
{
    public class QuizSessionViewModel
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string Category { get; set; }

        // List of question IDs selected for this session
        public List<int> QuestionIds { get; set; } = new();

        // Current question index in the quiz flow
        public int CurrentIndex { get; set; } = 0;

        // Number of correct answers
        public int CorrectAnswers { get; set; } = 0;

        // Computed score (percentage)
        public int Score =>
            QuestionIds == null || QuestionIds.Count == 0
                ? 0
                : (int)((double)CorrectAnswers / QuestionIds.Count * 100);
    }
}
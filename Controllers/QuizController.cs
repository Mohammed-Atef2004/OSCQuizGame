using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OOPAlgoQuizGame.Data;
using OOPAlgoQuizGame.Models;
using OOPAlgoQuizGame.ViewModels;
using System.Text.Json;

namespace OOPAlgoQuizGame.Controllers
{
    public class QuizController : Controller
    {
        private readonly QuizDbContext _db;
        private const string SESSION_KEY = "QuizSession";

        public QuizController(QuizDbContext db)
        {
            _db = db;
        }

        // -------------------------
        // Select Category
        // -------------------------
        [HttpGet]
        public IActionResult SelectCategory()
        {
            return View();
        }

        // -------------------------
        // Register
        // -------------------------
        [HttpGet]
        public IActionResult Register(string category)
        {
            if (string.IsNullOrWhiteSpace(category))
                return RedirectToAction(nameof(SelectCategory));

            ViewBag.Category = category;
            return View();
        }

        [HttpPost]
        public IActionResult Register(string name, string email, string category)
        {
            if (string.IsNullOrWhiteSpace(name) ||
                string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(category))
            {
                ViewBag.Error = "All fields are required.";
                ViewBag.Category = category;
                return View();
            }

            var session = new QuizSessionViewModel
            {
                Name = name.Trim(),
                Email = email.Trim(),
                Category = category.Trim(),
                QuestionIds = new List<int>(),
                CurrentIndex = 0,
                CorrectAnswers = 0
            };

            SaveSession(session);

            return RedirectToAction(nameof(Question));
        }

        // -------------------------
        // Question
        // -------------------------
        [HttpGet]
        public async Task<IActionResult> Question()
        {
            var session = LoadSession();
            if (session == null)
                return RedirectToAction(nameof(SelectCategory));

            // Initialize quiz questions once
            if (session.QuestionIds == null || session.QuestionIds.Count == 0)
            {
                var ids = await _db.Questions
                    .Where(q => q.Category == session.Category)
                    .OrderBy(x => Guid.NewGuid())
                    .Take(10)
                    .Select(x => x.Id)
                    .ToListAsync();

                if (!ids.Any())
                {
                    ViewBag.Error = "No questions found for this category.";
                    return View();
                }

                session.QuestionIds = ids;
                session.CurrentIndex = 0;
                session.CorrectAnswers = 0;

                SaveSession(session);
            }

            // Quiz finished
            if (session.CurrentIndex >= session.QuestionIds.Count)
                return RedirectToAction(nameof(Result));

            var questionId = session.QuestionIds[session.CurrentIndex];
            var question = await _db.Questions.FindAsync(questionId);

            if (question == null)
                return RedirectToAction(nameof(Result));

            // Move feedback from TempData to ViewBag so view can render explanation
            var lastCorrect = TempData["LastCorrect"] as string;
            if (!string.IsNullOrEmpty(lastCorrect))
            {
                ViewBag.LastFeedback = new
                {
                    IsCorrect = string.Equals(lastCorrect, "true", StringComparison.OrdinalIgnoreCase),
                    Selected = TempData["LastSelected"] as string ?? "",
                    CorrectLetter = TempData["LastCorrectLetter"] as string ?? "",
                    CorrectText = TempData["LastCorrectText"] as string ?? "",
                    Explanation = TempData["LastExplanation"] as string ?? ""
                };
            }

            ViewBag.Session = session;
            ViewBag.Progress = (int)((double)session.CurrentIndex / session.QuestionIds.Count * 100);

            return View(question);
        }

        // -------------------------
        // Answer (show feedback, do NOT advance index)
        // -------------------------
        [HttpPost]
        public async Task<IActionResult> Answer(int questionId, string selectedAnswer)
        {
            var session = LoadSession();
            if (session == null)
                return RedirectToAction(nameof(SelectCategory));

            if (session.QuestionIds == null ||
                session.CurrentIndex >= session.QuestionIds.Count)
            {
                return RedirectToAction(nameof(Result));
            }

            // Validate expected question
            var expectedQuestionId = session.QuestionIds[session.CurrentIndex];
            if (questionId != expectedQuestionId)
            {
                return RedirectToAction(nameof(Question));
            }

            var question = await _db.Questions.FindAsync(questionId);

            if (question != null && !string.IsNullOrWhiteSpace(selectedAnswer))
            {
                bool isCorrect = string.Equals(selectedAnswer.Trim(),
                    question.CorrectAnswer,
                    StringComparison.OrdinalIgnoreCase);

                if (isCorrect)
                {
                    // increment correct answers but do NOT advance the index yet
                    session.CorrectAnswers++;
                }

                // Save session with updated correct count but same CurrentIndex
                SaveSession(session);

                // prepare feedback data to show explanation on the following GET
                string correctLetter = question.CorrectAnswer ?? "";
                string correctText = correctLetter switch
                {
                    "A" => question.OptionA,
                    "B" => question.OptionB,
                    "C" => question.OptionC,
                    "D" => question.OptionD,
                    _ => ""
                };

                TempData["LastCorrect"] = isCorrect ? "true" : "false";
                TempData["LastSelected"] = selectedAnswer;
                TempData["LastCorrectLetter"] = correctLetter;
                TempData["LastCorrectText"] = correctText;
                TempData["LastExplanation"] = question.Explanation ?? "";
            }

            return RedirectToAction(nameof(Question));
        }

        // -------------------------
        // Continue (advance to next question after user saw feedback)
        // -------------------------
        [HttpPost]
        public IActionResult Continue()
        {
            var session = LoadSession();
            if (session == null)
                return RedirectToAction(nameof(SelectCategory));

            if (session.QuestionIds == null ||
                session.CurrentIndex >= session.QuestionIds.Count)
            {
                return RedirectToAction(nameof(Result));
            }

            session.CurrentIndex++;
            SaveSession(session);

            return RedirectToAction(nameof(Question));
        }

        // -------------------------
        // Result
        // -------------------------
        [HttpGet]
        public async Task<IActionResult> Result()
        {
            var session = LoadSession();
            if (session == null)
                return RedirectToAction(nameof(SelectCategory));

            // Save winner only if score >= 90
            if (session.Score >= 90)
            {
                bool exists = await _db.Winners.AnyAsync(w =>
                    w.Email == session.Email &&
                    w.Category == session.Category &&
                    w.Score == session.Score);

                if (!exists)
                {
                    _db.Winners.Add(new Winner
                    {
                        Name = session.Name,
                        Email = session.Email,
                        Category = session.Category,
                        Score = session.Score,
                        DateAchieved = DateTime.UtcNow
                    });

                    await _db.SaveChangesAsync();
                }
            }

            HttpContext.Session.Remove(SESSION_KEY);

            return View(session);
        }

        // -------------------------
        // Session Helpers
        // -------------------------
        private QuizSessionViewModel? LoadSession()
        {
            var json = HttpContext.Session.GetString(SESSION_KEY);

            if (string.IsNullOrEmpty(json))
                return null;

            return JsonSerializer.Deserialize<QuizSessionViewModel>(json);
        }

        private void SaveSession(QuizSessionViewModel session)
        {
            HttpContext.Session.SetString(
                SESSION_KEY,
                JsonSerializer.Serialize(session));
        }
    }
}
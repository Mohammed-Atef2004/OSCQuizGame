using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OOPAlgoQuizGame.Data;

namespace OOPAlgoQuizGame.Controllers
{
    public class AdminController : Controller
    {
        private readonly QuizDbContext _db;
        public AdminController(QuizDbContext db) => _db = db;

        public async Task<IActionResult> Winners(string category = "")
        {
            IQueryable<OOPAlgoQuizGame.Models.Winner> query = _db.Winners;

            if (!string.IsNullOrEmpty(category))
                query = query.Where(w => w.Category == category);

            var winners = await query
                .OrderByDescending(w => w.Score)
                .ThenBy(w => w.DateAchieved)
                .ToListAsync();

            ViewBag.SelectedCategory = category;
            ViewBag.Categories = new[] { "SP", "OOP", "DS", ".NET" };
            return View(winners);
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace OOPAlgoQuizGame.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() => View();
    }
}

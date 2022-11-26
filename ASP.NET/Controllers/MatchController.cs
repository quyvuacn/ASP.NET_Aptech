using Microsoft.AspNetCore.Mvc;
using WorldCup2022.Services;

namespace WorldCup2022.Controllers
{
    public class MatchController : Controller
    {
        private readonly MatchService matchService;
        public MatchController(MatchService matchService)
        {
            this.matchService = matchService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Show(int id) {
            var match = this.matchService.Where(match=>match.Id == id).First();
            return View(match);
        } 
    }
}

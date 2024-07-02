using Microsoft.AspNetCore.Mvc;

namespace PandapeWeb.Controllers
{
    public class CandidateController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

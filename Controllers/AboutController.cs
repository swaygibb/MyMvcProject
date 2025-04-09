using Microsoft.AspNetCore.Mvc;

namespace MyMvcProject.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

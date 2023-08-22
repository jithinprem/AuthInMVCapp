using Microsoft.AspNetCore.Mvc;

namespace StudentCourseWithAuth.Controllers
{
    public class MenuController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

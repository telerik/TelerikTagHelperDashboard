using Microsoft.AspNetCore.Mvc;

namespace TelerikTagHelperDashboard.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() => View();
    }
}

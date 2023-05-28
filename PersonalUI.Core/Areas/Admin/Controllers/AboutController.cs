using Microsoft.AspNetCore.Mvc;

namespace PersonalUI.Core.Areas.Admin.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

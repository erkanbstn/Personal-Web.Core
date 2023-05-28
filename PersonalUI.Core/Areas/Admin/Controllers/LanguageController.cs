using Microsoft.AspNetCore.Mvc;

namespace PersonalUI.Core.Areas.Admin.Controllers
{
    public class LanguageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

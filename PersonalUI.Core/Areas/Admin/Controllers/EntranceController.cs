using Microsoft.AspNetCore.Mvc;

namespace PersonalUI.Core.Areas.Admin.Controllers
{
    public class EntranceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

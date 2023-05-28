using Microsoft.AspNetCore.Mvc;

namespace PersonalUI.Core.Areas.Admin.Controllers
{
    public class ManagerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
